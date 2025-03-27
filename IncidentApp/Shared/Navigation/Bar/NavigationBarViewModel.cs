using IncidentApp.Pages.Home;
using IncidentApp.Shared.Commands;
using IncidentApp.Shared.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace IncidentApp.Shared.Navigation.Bar;

public class NavigationBarViewModel : ViewModelBase
{
    private ICommand? _backCommand;
    private ICommand? _homeCommand;

    private readonly INavigationService _navigationService;

    public NavigationBarViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    
    public ICommand NavigateHomeCommand => _homeCommand ??= new LambdaCommand(() =>
    {
        var home = App.Services.GetRequiredService<HomeViewModel>();
        _navigationService.Navigate(home);
    });

    public ICommand BackCommand => _backCommand ??= new LambdaCommand(() =>
    {
        // pu pu puuu
    });

    public MainViewModel? MainViewModel { get; set; }

    public bool IsEnabledHomeButton => true;
}