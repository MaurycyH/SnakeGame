using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeSense.MainWindow
{

    //ViewModel for MainWindow
    public class MainWindowViewModel : NotifyViewModel
    {
        private int mXPosition;
        private int mYPosition;
        private int mXSpeed;
        private int mYSpeed;

        // Property for X Position of snake
        public int XPosition
        {
            get 
            { 
                return mXPosition; 
            }
            set 
            {
                mXPosition = value;
                OnPropertyChanged(nameof(XPosition));
            }
        }
        // Property for Y Position of snake
        public int YPosition
        {
            get
            {
                return mYPosition;
            }
            set
            {
                mYPosition = value;
                OnPropertyChanged(nameof(YPosition));
            }
        }
        public Timer Timer { get; set; }
        //Default Constructor
        public MainWindowViewModel()
        {
            XPosition = 150;
            YPosition = 100;
            mXSpeed = 15;
            Timer = new Timer(100);

            Timer.Elapsed += new ElapsedEventHandler(MoveSnake);
            Timer.Enabled = true;
        }
        public void MoveSnake(object source, ElapsedEventArgs e)
        {
            XPosition += mXSpeed;
            
        }
    }
}
