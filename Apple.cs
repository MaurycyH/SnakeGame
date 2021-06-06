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
        /// <summary>
        /// Constructor which sets X and Y of first apple
        /// </summary>
        public Apple()
        {
            XPosition = 600;
            YPosition = 250;
        }

        /// <summary>
        /// Randomly spawns next Apple between borders (default size window)
        /// </summary>
        public void SpawnNextApple()
        {
            Random random = new Random();
            XPosition = random.Next(25, 650);
            YPosition = random.Next(25, 400);
        }
    }
}
