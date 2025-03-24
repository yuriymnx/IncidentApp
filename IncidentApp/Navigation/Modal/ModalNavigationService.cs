using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Navigation.Modal;

public class ModalNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
{
    private readonly ModalNavigationMediator _navigationMediator;
    private readonly CreateViewModel<TViewModel> _createViewModel;
    public ModalNavigationService(ModalNavigationMediator navigationMediator, CreateViewModel<TViewModel> createViewModel)
    {
        _navigationMediator = navigationMediator;
        _createViewModel = createViewModel;
    }

    public void Navigate()
    {
        _navigationMediator.CurrentViewModel = _createViewModel();
    }
}