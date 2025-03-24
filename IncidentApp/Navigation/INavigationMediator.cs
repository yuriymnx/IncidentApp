using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Navigation;

public interface INavigationMediator
{
    ViewModelBase CurrentViewModel { set; }
}