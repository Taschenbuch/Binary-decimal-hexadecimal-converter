using System;
using System.Windows.Input;

namespace BinHexDecConverter
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            _methodToExecute     = methodToExecute;
            _canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }

        #region ICommand members

        public bool CanExecute(object parameter)
        {
            if (_canExecuteEvaluator == null)
                return true;

            return _canExecuteEvaluator.Invoke();
        }

        public void Execute(object parameter)
        {
            _methodToExecute.Invoke();
        }

        #endregion

        #region Fields

        private readonly Action     _methodToExecute;
        private readonly Func<bool> _canExecuteEvaluator;

        #endregion
    }
}