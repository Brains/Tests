using System;

namespace WPF
{
    public class CommandDelegate<T> : System.Windows.Input.ICommand
    {
        private readonly Predicate<T> canExecute;
        private readonly Action<T> execute;

        public CommandDelegate(Action<T> execute)
            : this(execute, null)
        {
        }

        public CommandDelegate(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;

            return canExecute((parameter == null) ? default(T) : (T) Convert.ChangeType(parameter, typeof(T)));
        }

        public void Execute(object parameter)
        {
            execute((parameter == null) ? default(T) : (T) Convert.ChangeType(parameter, typeof(T)));
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}