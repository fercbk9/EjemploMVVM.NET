using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMProject.Utils.Commands
{
    public class ParamCommand : ICommand
    {
        private Action<object> _action;
        private readonly Func<bool> canExecute;

        public ParamCommand(Action<object> action)
        {
            _action = action;
            canExecute = () => true;
        }
        public ParamCommand(Action<object> action,Func<bool> canExecute)
        {
            this._action = action;
            this.canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecute.Invoke();
                return result;
            }
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                if (parameter != null)
                {
                    _action(parameter);
                }
            }
        }
    }
}
