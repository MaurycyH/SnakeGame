using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeSense
{
    /// <summary>
    /// Class defining Snakes body parts
    /// </summary>
    public class SnakesBody : NotifyModel
    {
        private int mXPosition;
        private int mYPosition;
        private int mXSpeed;
        private int mYSpeed;

        // Property for X Position of snake body part
        public int XPosition
        {
            get => mXPosition;
            set
            {
                mXPosition = value;
                OnPropertyChanged(nameof(XPosition));
            }
        }
        // Property for Y Position of snake body part
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

        /// <summary>
        /// Constructor which sets X,Y position of body part
        /// </summary>
        /// <param name="left">X position of body part</param>
        /// <param name="top">Y position of body part</param>
        public SnakesBody(int left, int top)
        {
            XPosition = left;
            YPosition = top;
        }
        /// <summary>
        /// Moves Snakes Body according to its previous part
        /// </summary>
        /// <param name="source"> Source of the event, Timer </param>
        /// <param name="e">Information from Timer</param>
        /// <param name="previousSnakesBody"> Previous body part</param>
        public void MoveSnakesBody(object source, ElapsedEventArgs e,SnakesBody previousSnakesBody)
        {
            XPosition = previousSnakesBody.XPosition;
            YPosition = previousSnakesBody.YPosition;
            XSpeed = previousSnakesBody.XSpeed;
            YSpeed = previousSnakesBody.YSpeed;

        }
        /// <summary>
        ///  Moves Snakes Body according to snake head
        /// </summary>
        /// <param name="source"> Source of the event, Timer</param>
        /// <param name="e">Information from Timer</param>
        /// <param name="snake"> head of snake</param>
        public void MoveOneSnakeBody(object source, ElapsedEventArgs e, Snake snake)
        {
            if (snake.XSpeed == 15)
            {
                XPosition = snake.XPosition - 15;
                YPosition = snake.YPosition;
                XSpeed = snake.XSpeed;
            }
            else if (snake.XSpeed == -15)
            {
                XPosition = snake.XPosition + 15;
                YPosition = snake.YPosition;
                XSpeed = snake.XSpeed;
            }
            else if (snake.YSpeed == 15)
            {
                XPosition = snake.XPosition;
                YPosition = snake.YPosition - 15;
                YSpeed = snake.YSpeed;
            }
            else if (snake.YSpeed == -15)
            {
                XPosition = snake.XPosition;
                YPosition = snake.YPosition + 15;
                YSpeed = snake.YSpeed;
            }

        }
    }
}
