using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowFM.Shared.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _open;

        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<object> open)
        {
            this._open = open;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter) => _open?.Invoke(obj: parameter);
    }
}
