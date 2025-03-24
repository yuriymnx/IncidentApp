using IncidentApp.Shared.Commands;
using IncidentApp.Shared.ViewModels;
using System.Windows.Input;

namespace IncidentApp.Navigation.Bar;

public class NavigationBarViewModel : ViewModelBase
{
    public NavigationBarViewModel(INavigationService homeNavigationService, INavigationService closeNavigationService)
    {
        CloseModalCommand = new NavigateCommand(closeNavigationService);
        NavigateHomeCommand = new NavigateCommand(homeNavigationService);
    }

    private ICommand? _backCommand;

    public ICommand BackCommand => _backCommand ??= new LambdaCommand(() =>
    {
        if (MainViewModel?.CurrentModalViewModel is null)
        {
            NavigateHomeCommand.Execute(null);
            return;
        }

        CloseModalCommand.Execute(null);
    });

    private ICommand CloseModalCommand { get; }
    public ICommand NavigateHomeCommand { get; }
    public MainViewModel? MainViewModel { get; set; }

    public bool IsEnabledHomeButton => true;
}