using System;
using System.Threading.Tasks;

namespace IncidentApp.Shared.Commands;

public class LambdaCommandAsync : CommandBase
{
    private readonly Func<object?, Task> _executeAsync;
    private readonly Func<object?, bool>? _canExecuteAsync;
    private readonly bool _background;

    private Task? _executingTask;

    public LambdaCommandAsync(Func<object?, Task> executeAsync, bool? background = false, Func<object?, bool>? canExecuteAsync = null)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _background = background ?? false;
        _canExecuteAsync = canExecuteAsync;
    }
    
    protected override bool CanExecute(object? parameter) =>
        (_executingTask is null || _executingTask.IsCompleted) &&
        (_canExecuteAsync?.Invoke(parameter) ?? true);

    protected override async void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
            return;

        var executeTask = _background
            ? Task.Run(() => _executeAsync(parameter))
            : _executeAsync(parameter);

        _executingTask = executeTask;
        RaiseCanExecuteChanged();

        try
        {
            await executeTask.ConfigureAwait(true);
        }
        catch (OperationCanceledException)
        {
            // Игнорируем отменённые операции
        }
        finally
        {
            _executingTask = null;
            RaiseCanExecuteChanged();
        }
    }
}
