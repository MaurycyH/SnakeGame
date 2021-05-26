using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeSense.MainWindow
{

    //ViewModel for MainWindow
    public class MainWindowViewModel
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
            }
        }
        //Default Constructor
        public MainWindowViewModel()
        {
            XPosition = 150;
            YPosition = 100;
        }
    }
}
