using System;

namespace SnakeSense
{
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
        Random Random = new Random();
        public Apple()
        {
            XPosition = Random.Next(25, 650);
            YPosition = Random.Next(25, 400);
        }

        public void SpawnNextApple()
        {
            XPosition = Random.Next(25, 650);
            YPosition = Random.Next(25, 400);
        }
    }
}
