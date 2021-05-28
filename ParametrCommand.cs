using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnakeSense
{
    public class ParameterCommand : ICommand
    {
        private Action<object> mAction;
        private bool mCanExecute;
        public ParameterCommand(Action<object> action, bool canExecute)
        {
            mAction = action;
            mCanExecute = canExecute;
        }
        
        public bool CanExecute(object parameter)
        {
            return mCanExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            mAction(parameter);
        }
    }
}
