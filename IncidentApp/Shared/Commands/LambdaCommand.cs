using System;

namespace IncidentApp.Shared.Commands;

public class LambdaCommand : CommandBase
{
    private readonly Action<object?> _execute;
    private readonly Func<object?, bool>? _canExecute;

    public LambdaCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public LambdaCommand(Action execute, Func<bool>? canExecute = null)
        : this(p => execute(), canExecute is null ? null : _ => canExecute())
    {
    }

    protected override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    protected override void Execute(object? parameter) => _execute(parameter);
}

