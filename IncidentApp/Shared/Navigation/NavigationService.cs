using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Shared.Navigation;

public class NavigationService : INavigationService
{
    private readonly NavigationMediator _navigationMediator;

    public NavigationService(NavigationMediator navigationMediator)
    {
        _navigationMediator = navigationMediator;
    }

    public void Navigate(ViewModelBase viewModel)
    {
        _navigationMediator.CurrentViewModel = viewModel;
    }
}