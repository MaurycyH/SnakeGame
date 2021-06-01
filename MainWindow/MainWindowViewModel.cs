using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using SnakeSense.Helpers;

namespace SnakeSense.MainWindow
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class MainWindowViewModel : NotifyModel
    {
        object mSnakesBodyLock = new object();
        private double mWindowHeight;
        private double mWindowWidth;
        private bool IfPause = false;
        private ImageSource mBackgroundImage;
      //  BitmapImage bitmapImage;
        public ObservableCollection<SnakesBody> SnakesBody { get; }

        public ImageSource BackgroundImage
        {
            get
            {
                return mBackgroundImage;
            }
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
            Timer = new Timer(35);
            mWindowHeight = App.Current.MainWindow.Height;
            mWindowWidth = App.Current.MainWindow.Width;
            SnakesBody = new ObservableCollection<SnakesBody>();
            DownloadImageHelper = new DownloadImageHelper();
            BindingOperations.EnableCollectionSynchronization(SnakesBody, mSnakesBodyLock);
            Timer.Elapsed += new ElapsedEventHandler(RefreshSnakePosition);
            Timer.Enabled = true;

        }
        /// <summary>
        /// Must be Async Void because handlers are only async void
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public async void RefreshSnakePosition(object source, ElapsedEventArgs e)
        {
            if (ChceckBorder())
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
                lock (mSnakesBodyLock)
                {
                    if (Snake.Score == 0)
                    {
                        if (Snake.XSpeed == 10)
                        {
                            SnakesBody.Add(new SnakesBody(Snake.XPosition - 15, Snake.YPosition));
                        }
                        else if (Snake.XSpeed == -10)
                        {
                            SnakesBody.Add(new SnakesBody(Snake.XPosition + 15, Snake.YPosition));
                        }
                        else if (Snake.YSpeed == 10)
                        {
                            SnakesBody.Add(new SnakesBody(Snake.XPosition, Snake.YPosition - 15));
                        }
                        else if (Snake.YSpeed == -10)
                        {
                            SnakesBody.Add(new SnakesBody(Snake.XPosition, Snake.YPosition + 15));
                        }

                    }
                    else
                    {
                        if (SnakesBody.Last().XSpeed == 10)
                        {
                            SnakesBody.Add(new SnakesBody(SnakesBody.Last().XPosition - 15, SnakesBody.Last().YPosition));
                        }
                        else if (SnakesBody.Last().XSpeed == -10)
                        {
                            SnakesBody.Add(new SnakesBody(SnakesBody.Last().XPosition + 15, SnakesBody.Last().YPosition));
                        }
                        else if (SnakesBody.Last().YSpeed == 10)
                        {
                            SnakesBody.Add(new SnakesBody(SnakesBody.Last().XPosition, SnakesBody.Last().YPosition - 15));
                        }
                        else if (SnakesBody.Last().YSpeed == -10)
                        {
                            SnakesBody.Add(new SnakesBody(SnakesBody.Last().XPosition, SnakesBody.Last().YPosition + 15));
                        }

                    }
                }

                Snake.Score += 1;
                await DownloadImageHelper.GetImageAsync(new System.Threading.CancellationToken());
                // Memory leak?
                App.Current.Dispatcher.Invoke(() =>
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.UriSource = new Uri(DownloadImageHelper.PathToNewImage);
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    Dispatcher.CurrentDispatcher.Invoke(() => BackgroundImage = bitmapImage);
                });
            }
        }
        public bool ChceckBorder()
        {
            if (!IfPause)
            {
                // Bug with height?
                if ((Snake.XPosition + 30 >= mWindowWidth) || (Snake.YPosition + 30 >= mWindowHeight) || (Snake.XPosition <= 0) || (Snake.YPosition <= 0))
                {
                    Snake.YSpeed = 0;
                    Snake.XSpeed = 0;
                    IfPause = true;
                    MessageBox.Show("Przegrales bo poza granice wyszedles");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool CheckAppleEat()
        {
            if (!IfPause)
            {
                if ((Snake.XPosition >= Apple.XPosition - 15) && (Snake.XPosition <= Apple.XPosition + 15) && (Snake.YPosition >= Apple.YPosition - 15) && (Snake.YPosition <= Apple.YPosition + 15))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}