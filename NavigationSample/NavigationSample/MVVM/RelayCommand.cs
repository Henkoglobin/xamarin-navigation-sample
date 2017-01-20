using System;
using System.Windows.Input;

namespace NavigationSample.MVVM {
    public class RelayCommand : ICommand {
        private readonly Action action;
        private readonly Func<bool> predicate;

        public RelayCommand(Action navigate, Func<bool> predicate = null) {
            this.action = navigate;
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
            => this.predicate?.Invoke() ?? true;

        public void Execute(object parameter)
            => this.action();

        public void RaiseCanExecuteChanged() {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
