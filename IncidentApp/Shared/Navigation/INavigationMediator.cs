using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Shared.Navigation;

public interface INavigationMediator
{
    ViewModelBase CurrentViewModel { set; }
}