using System.Windows.Input;
using System;

namespace SomeQuest.Commands {
    public abstract class CommandBase : ICommand {
        public event EventHandler? CanExecuteChanged;
        public virtual bool CanExecute(object? parameter) => true;
        public abstract void Execute(object? parameter);
        protected void OnExecuteChanged() {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
