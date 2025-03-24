using IncidentApp.Shared.Commands;

namespace IncidentApp.Shared.Navigation;

public class NavigateCommand : CommandBase
{
    private readonly INavigationService _navigationService;

    public NavigateCommand(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override void Execute(object? parameter)
    {
        _navigationService.Navigate();
    }
}