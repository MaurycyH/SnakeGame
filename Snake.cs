using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace SnakeSense
{
    public class Snake : NotifyModel
    {
        private int mXPosition;
        private int mYPosition;
        private int mXSpeed;
        private int mYSpeed;
        private int mScore;

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
        public int Score
        {
            get
            {
                return mScore;
            }
            set
            {
                mScore = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public ICommand KeyCommand { get; }
        public Snake()
        {
            XPosition = 150;
            YPosition = 100;
            Score = 0;
            KeyCommand = new ParameterCommand(parameter => KeyPressed(parameter), true);
        }
        public void MoveSnake(object source, ElapsedEventArgs e)
        {
            XPosition += XSpeed;
            YPosition += YSpeed;

        }
        public void KeyPressed(object Key)
        {
            string Direction;
            Direction = Key as string;
            switch (Direction)
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
