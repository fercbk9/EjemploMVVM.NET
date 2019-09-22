using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMProject.Utils.Commands
{
    public class RelayCommand : ICommand
    {
        private Action action;
        private readonly Func<bool> _canExecute;


        public RelayCommand(Action action, Func<bool> _canExecute)
        {
            this.action = action;
            this._canExecute = _canExecute;
        }

        public RelayCommand(Action action)
        {
            this.action = action;
            _canExecute = () => true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = _canExecute.Invoke();
            return result;
        }

        public void Execute(object parameter)
        {
            action.Invoke();
        }


    }
}
