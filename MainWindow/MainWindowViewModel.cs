using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

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
        public int XSpeed
        {
            get
            {
                return mXSpeed;
            }
            set
            {
                mXSpeed = value;
                OnPropertyChanged(nameof(XSpeed));
            }
        }
        public int YSpeed
        {
            get
            {
                return mYSpeed;
            }
            set
            {
                mYSpeed = value;
                OnPropertyChanged(nameof(YSpeed));
            }
        }
        // Using it for refresh screen im not sure if it is better than DrawingVisual
        public Timer Timer { get; set; }

        public ICommand KeyCommand { get; }
        //Default Constructor
        public MainWindowViewModel()
        {
            Timer = new Timer(150);
            XPosition = 150;
            YPosition = 100;
            Timer.Elapsed += new ElapsedEventHandler(MoveSnake);
            Timer.Enabled = true;
            KeyCommand = new ParametrCommand(parametr => KeyPressed(parametr),true);
 
        }
        public void MoveSnake(object source, ElapsedEventArgs e)
        {
            XPosition += XSpeed;
            YPosition += YSpeed;
            
        }
        public void KeyPressed(object argument)
        {
            string Direction;
            Direction = argument as string;
            switch(Direction)
            {
                case "UpKey":
                    YSpeed = -10;
                    XSpeed = 0;
                    break;
                case "DownKey":
                    YSpeed = 10;
                    XSpeed = 0;
                    break;
                case "LeftKey":
                    YSpeed = 0;
                    XSpeed = -10;
                    break;
                case "RightKey":
                    YSpeed = 0;
                    XSpeed = 10;
                    break;
                default:
                    break;
            }
               
           
        }
    }
}
