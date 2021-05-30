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

        
        public SnakesBody(int left, int top)
        {
            XPosition = left;
            YPosition = top;
        }
        public void MoveSnakesBody(object source, ElapsedEventArgs e,SnakesBody PreviousSnakesBody)
        {
            XPosition = PreviousSnakesBody.XPosition;
            YPosition = PreviousSnakesBody.YPosition;

        }
        public void MoveOneSnakeBody(object source, ElapsedEventArgs e, Snake snake)
        {
            if (snake.XSpeed == 10)
            {
                XPosition = snake.XPosition - 10;
                YPosition = snake.YPosition;
            }
            else if (snake.XSpeed == -10)
            {
                XPosition = snake.XPosition + 10;
                YPosition = snake.YPosition;
            }
            else if (snake.YSpeed == 10)
            {
                XPosition = snake.XPosition;
                YPosition = snake.YPosition - 10;
            }
            else if (snake.YSpeed == -10)
            {
                XPosition = snake.XPosition;
                YPosition = snake.YPosition + 10;
            }

        }
    }
}
