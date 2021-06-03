using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeSense
{
    public class SnakesBody : NotifyModel
    {
        private int mXPosition;
        private int mYPosition;
        private int mXSpeed;
        private int mYSpeed;

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

        
        public SnakesBody(int left, int top)
        {
            XPosition = left;
            YPosition = top;
        }
        public void MoveSnakesBody(object source, ElapsedEventArgs e,SnakesBody previousSnakesBody)
        {
            XPosition = previousSnakesBody.XPosition;
            YPosition = previousSnakesBody.YPosition;
            XSpeed = previousSnakesBody.XSpeed;
            YSpeed = previousSnakesBody.YSpeed;

        }
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
