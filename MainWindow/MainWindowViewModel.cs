using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using SnakeSense.Helpers;
using Timer = System.Timers.Timer;

namespace SnakeSense.MainWindow
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class MainWindowViewModel : NotifyModel
    {
        private object mSnakesBodyLock = new object();
        private double mWindowHeight;
        private double mWindowWidth;
        private bool mIfPause;
        private ImageSource mBackgroundImage;
        public ObservableCollection<SnakesBody> SnakesBody { get; }

        public ImageSource BackgroundImage
        {
            get => mBackgroundImage;
            set
            {
                mBackgroundImage = value;
                OnPropertyChanged(nameof(BackgroundImage));
            }
        }
        /// <summary>
        ///  Object representing Snake
        /// </summary>
        public Snake Snake { get; }
        /// <summary>
        /// Object representing Apple
        /// </summary>
        public Apple Apple { get; }
        /// <summary>
        /// Using it for refresh screen im not sure if it is better than DrawingVisual
        /// </summary>
        public Timer Timer { get; set; }

        public DownloadImageHelper DownloadImageHelper;
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        public MainWindowViewModel()
        {

            Snake = new Snake();
            Apple = new Apple();
            Timer = new Timer(50);
            mWindowHeight = Application.Current.MainWindow.Height;
            mWindowWidth = Application.Current.MainWindow.Width;
            SnakesBody = new ObservableCollection<SnakesBody>();
            DownloadImageHelper = new DownloadImageHelper();
            BindingOperations.EnableCollectionSynchronization(SnakesBody, mSnakesBodyLock);
            Timer.Elapsed += RefreshSnakePosition;
            Timer.Enabled = true;

        }
        /// <summary>
        /// Must be Async Void because handlers are only async void
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public async void RefreshSnakePosition(object source, ElapsedEventArgs e)
        {

            if (CheckBorder() && CheckBodyCollision())
            {
                Snake.MoveSnake(source, e);
                for (int i = SnakesBody.Count() - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        SnakesBody[i].MoveOneSnakeBody(source, e, Snake);
                    }
                    else
                    {
                        SnakesBody[i].MoveSnakesBody(source, e, SnakesBody[i - 1]);
                    }
                }
            }


            if (CheckAppleEat())
            {
                Apple.SpawnNextApple();
                // Lock to change  collection view 
                lock (mSnakesBodyLock)
                {
                    if (Snake.Score == 0)
                    {
                        if (Snake.XSpeed == 15)
                        {
                            SnakesBody.Add(new SnakesBody(Snake.XPosition - 15, Snake.YPosition));
                        }
                        else if (Snake.XSpeed == -15)
                        {
                            SnakesBody.Add(new SnakesBody(Snake.XPosition + 15, Snake.YPosition));
                        }
                        else if (Snake.YSpeed == 15)
                        {
                            SnakesBody.Add(new SnakesBody(Snake.XPosition, Snake.YPosition - 15));
                        }
                        else if (Snake.YSpeed == -15)
                        {
                            SnakesBody.Add(new SnakesBody(Snake.XPosition, Snake.YPosition + 15));
                        }

                    }
                    else
                    {
                        if (SnakesBody.Last().XSpeed == 15)
                        {
                            SnakesBody.Add(new SnakesBody(SnakesBody.Last().XPosition - 15, SnakesBody.Last().YPosition));
                        }
                        else if (SnakesBody.Last().XSpeed == -15)
                        {
                            SnakesBody.Add(new SnakesBody(SnakesBody.Last().XPosition + 15, SnakesBody.Last().YPosition));
                        }
                        else if (SnakesBody.Last().YSpeed == 15)
                        {
                            SnakesBody.Add(new SnakesBody(SnakesBody.Last().XPosition, SnakesBody.Last().YPosition - 15));
                        }
                        else if (SnakesBody.Last().YSpeed == -15)
                        {
                            SnakesBody.Add(new SnakesBody(SnakesBody.Last().XPosition, SnakesBody.Last().YPosition + 15));
                        }

                    }
                }

                Snake.Score += 1;

                await DownloadImageHelper.GetImageAsync();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = new Uri(DownloadImageHelper.PathToNewImage);
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                Dispatcher.CurrentDispatcher.Invoke(() => BackgroundImage = bitmapImage);


            }
        }
        public bool CheckBorder()
        {
            if (!mIfPause)
            {
                //  Size of window need to be %15
                if ((Snake.XPosition + Snake.XSpeed + 15 >= mWindowWidth) || (Snake.YPosition + Snake.YSpeed + 15 >= mWindowHeight - 30) || (Snake.XPosition <= 0) || (Snake.YPosition - 15 <= 0))
                {
                    Snake.YSpeed = 0;
                    Snake.XSpeed = 0;
                    mIfPause = true;
                    MessageBox.Show("Przegrales bo poza granice wyszedles");
                    return false;
                }

                return true;
            }

            return false;
        }

        public bool CheckBodyCollision()
        {
            if (!mIfPause)
            {

                for (int i = SnakesBody.Count() - 1; i >= 0; i--)
                {
                    if (Snake.XPosition == SnakesBody[i].XPosition && Snake.YPosition == SnakesBody[i].YPosition)
                    {
                        Snake.YSpeed = 0;
                        Snake.XSpeed = 0;
                        mIfPause = true;
                        MessageBox.Show("Przegrales bo uderzyles w ogon");
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public bool CheckAppleEat()
        {
            if (!mIfPause)
            {
                return (Snake.XPosition >= Apple.XPosition - 15) && (Snake.XPosition <= Apple.XPosition + 15) && (Snake.YPosition >= Apple.YPosition - 15) && (Snake.YPosition <= Apple.YPosition + 15);
            }

            return false;
        }
    }
}