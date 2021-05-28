using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace SnakeSense.MainWindow
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class MainWindowViewModel : NotifyModel
    {
        private double mWindowHeight;
        private double mWindowWidth;
        private bool IfPause = false;
        /// <summary>
        ///  Object representing Snake
        /// </summary>
        public Snake Snake { get; }

        public Apple Apple { get; }
        /// <summary>
        /// Using it for refresh screen im not sure if it is better than DrawingVisual
        /// </summary>
        public Timer Timer { get; set; }
        /// <summary>
        /// Command for key input
        /// </summary>
       // public ICommand KeyCommand { get; }
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        public MainWindowViewModel()
        {
            Snake = new Snake();
            Apple = new Apple();
            Timer = new Timer(50);
            mWindowHeight = App.Current.MainWindow.Height;
            mWindowWidth = App.Current.MainWindow.Width;
            Timer.Elapsed += new ElapsedEventHandler(RefreshSnakePosition);
            Timer.Enabled = true;
            
        }
        public void RefreshSnakePosition(object source, ElapsedEventArgs e)
        {
            if (ChceckBorder())
            {
                Snake.MoveSnake(source, e);
            }
          

        }
        public bool ChceckBorder()
        {
            if (!IfPause)
            {
                if ((Snake.XPosition >= mWindowWidth) || (Snake.YPosition >= mWindowHeight) || (Snake.XPosition <= 0) || (Snake.YPosition <= 0))
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
    }
}