using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Shared.Navigation;

public class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly CreateViewModel<TViewModel> _createViewModel;

    private readonly INavigationMediator _navigationMediator;

    public NavigationService(INavigationMediator navigationMediator, CreateViewModel<TViewModel> createViewModel)
    {
        _createViewModel = createViewModel;
        _navigationMediator = navigationMediator;  
    }

    public void Navigate()
    {
        _navigationMediator.CurrentViewModel = _createViewModel();
    }
}