using System;
using System.ComponentModel;
using System.Windows.Input;

namespace IncidentApp.Shared.Commands;

public abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged;

    bool ICommand.CanExecute(object? parameter) => CanExecute(parameter);

    void ICommand.Execute(object? parameter)
    {
        if (CanExecute(parameter))
            Execute(parameter);
    }

    protected virtual bool CanExecute(object? parameter) => true;

    protected void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    protected abstract void Execute(object? parameter);

    /// <summary>
    /// Автоматически вызывает обновление команды при изменении указанного свойства.
    /// </summary>
    /// <param name="notifier">Объект, реализующий INotifyPropertyChanged</param>
    /// <param name="propertyName">Имя свойства, изменение которого должно вызвать обновление команды</param>
    public void AutoRaiseOn(INotifyPropertyChanged notifier, string propertyName)
    {
        notifier.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == propertyName)
            {
                RaiseCanExecuteChanged();
            }
        };
    }
}

