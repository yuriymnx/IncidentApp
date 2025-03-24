using System;
using System.Threading.Tasks;

namespace IncidentApp.Shared.Commands;

public abstract class AsyncCommandBase : CommandBase
{
    private readonly Action<Exception>? _onException;

    private bool _isExecuting;

    protected AsyncCommandBase(Action<Exception>? onException)
    {
        _onException = onException;
    }

    private bool IsExecuting
    {
        get => _isExecuting;
        set
        {
            _isExecuting = value;
            RaiseCanExecuteChanged();
        }
    }

    protected sealed override async void Execute(object? parameter)
    {
        if (IsExecuting) return;

        IsExecuting = true;

        try
        {
            await ExecuteAsync(parameter);
        }
        catch (Exception exception)
        {
            _onException?.Invoke(exception);
        }
        finally
        {
            IsExecuting = false;
        }
    }

    protected sealed override bool CanExecute(object? parameter) => !IsExecuting && CanExecuteAsync(parameter);

    protected abstract Task ExecuteAsync(object? parameter);

    protected virtual bool CanExecuteAsync(object? parameter) => true;
}