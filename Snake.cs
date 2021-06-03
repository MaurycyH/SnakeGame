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
            get => mXPosition;
            set
            {
                mXPosition = value;
                OnPropertyChanged(nameof(XPosition));
            }
        }
        // Property for Y Position of snake
        public int YPosition
        {
            get => mYPosition;
            set
            {
                mYPosition = value;
                OnPropertyChanged(nameof(YPosition));
            }
        }
        public int XSpeed
        {
            get => mXSpeed;
            set
            {
                mXSpeed = value;
                OnPropertyChanged(nameof(XSpeed));
            }
        }
        public int YSpeed
        {
            get => mYSpeed;
            set
            {
                mYSpeed = value;
                OnPropertyChanged(nameof(YSpeed));
            }
        }
        public int Score
        {
            get => mScore;
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
            YPosition = 200;
            Score = 0;
            KeyCommand = new ParameterCommand(KeyPressed, true);
        }
        public void MoveSnake(object source, ElapsedEventArgs e)
        {
            XPosition += XSpeed;
            YPosition += YSpeed;

        }
        public void KeyPressed(object key)
        {
            string direction = key as string;
            switch (direction)
            {
                case "UpKey":
                    if (YSpeed != 15)
                    {
                        YSpeed = -15;
                        XSpeed = 0;
                    }
                    break;
                case "DownKey":
                    if (YSpeed != -15)
                    {
                        YSpeed = 15;
                        XSpeed = 0;
                    }
                    break;
                case "LeftKey":
                    if (XSpeed != 15)
                    {
                        YSpeed = 0;
                        XSpeed = -15;
                    }
                    break;
                case "RightKey":
                    if (XSpeed != -15)
                    {
                        YSpeed = 0;
                        XSpeed = 15;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
