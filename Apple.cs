using System;

namespace SnakeSense
{
    /// <summary>
    /// Class defining Apple object
    /// </summary>
    public class Apple : NotifyModel
    {
        private int mXPosition;
        private int mYPosition;

        // Property for X Position of Apple
        public int XPosition
        {
            get => mXPosition;
            set
            {
                mXPosition = value;
                OnPropertyChanged(nameof(XPosition));
            }
        }
        // Property for Y Position of Apple
        public int YPosition
        {
            get => mYPosition;
            set
            {
                mYPosition = value;
                OnPropertyChanged(nameof(YPosition));
            }
        }
        public Apple()
        {
            XPosition = 600;
            YPosition = 250;
        }

        public void SpawnNextApple()
        {
            Random random = new Random();
            XPosition = random.Next(25, 650);
            YPosition = random.Next(25, 400);
        }
    }
}
