using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeSense
{
    public class SnakesBody : NotifyModel
    {
        private int mXPosition;
        private int mYPosition;


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
        public SnakesBody(int left, int top)
        {
            XPosition = left;
            YPosition = top;
        }
    }
}
