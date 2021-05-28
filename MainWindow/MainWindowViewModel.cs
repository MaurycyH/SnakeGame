using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace SnakeSense.MainWindow
{

    //ViewModel for MainWindow
    public class MainWindowViewModel : NotifyViewModel
    {
        /// <summary>
        ///  Object representing Snake
        /// </summary>
        public Snake Snake { get; }
        /// <summary>
        /// Using it for refresh screen im not sure if it is better than DrawingVisual
        /// </summary>
        public Timer Timer { get; set; }
        /// <summary>
        /// Command for key input
        /// </summary>
        public ICommand KeyCommand { get; }
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        public MainWindowViewModel()
        {
            Snake = new Snake();
            Timer = new Timer(150);           
            Timer.Elapsed += new ElapsedEventHandler(RefreshSnakePosition);
            Timer.Enabled = true;

        }
        public void RefreshSnakePosition(object source, ElapsedEventArgs e)
        {
            Snake.MoveSnake(source, e);

        }
    }
}