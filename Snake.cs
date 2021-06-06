using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace SnakeSense
{
    /// <summary>
    /// Class defining Snake object
    /// </summary>
    public class Snake : NotifyModel
    {
        private int mXPosition;
        private int mYPosition;
        private int mXSpeed;
        private int mYSpeed;
        private int mScore;

        /// <summary>
        /// Property for X Position of snake
        /// </summary>
        public int XPosition
        {
            get => mXPosition;
            set
            {
                mXPosition = value;
                OnPropertyChanged(nameof(XPosition));
            }
        }
        /// <summary>
        ///  Property for Y Position of snake
        /// </summary>
        public int YPosition
        {
            get => mYPosition;
            set
            {
                mYPosition = value;
                OnPropertyChanged(nameof(YPosition));
            }
        }
        /// <summary>
        /// Property for speed for X axis of snake
        /// </summary>
        public int XSpeed
        {
            get => mXSpeed;
            set
            {
                mXSpeed = value;
                OnPropertyChanged(nameof(XSpeed));
            }
        }
        /// <summary>
        /// Property for speed for Y axis of snake
        /// </summary>
        public int YSpeed
        {
            get => mYSpeed;
            set
            {
                mYSpeed = value;
                OnPropertyChanged(nameof(YSpeed));
            }
        }
        /// <summary>
        /// Property represents score which player get
        /// </summary>
        public int Score
        {
            get => mScore;
            set
            {
                mScore = value;
                OnPropertyChanged(nameof(Score));
            }
        }
        /// <summary>
        /// Command that takes keyboard input
        /// </summary>
        public ICommand KeyCommand { get; }

        /// <summary>
        /// Constructor that sets X and Y position at start and initialize Score and KeyCommand
        /// </summary>
        public Snake()
        {
            XPosition = 150;
            YPosition = 200;
            Score = 0;
            KeyCommand = new ParameterCommand(KeyPressed, true);
        }
        /// <summary>
        /// Moves the snake accordingly to direction that he move
        /// </summary>
        /// <param name="source">Timer</param>
        /// <param name="e">Timer Data</param>
        public void MoveSnake(object source, ElapsedEventArgs e)
        {
            XPosition += XSpeed;
            YPosition += YSpeed;

        }
        /// <summary>
        /// Takes keyboard input and converts it to snake speed
        /// </summary>
        /// <param name="key">Keyboard input</param>
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
