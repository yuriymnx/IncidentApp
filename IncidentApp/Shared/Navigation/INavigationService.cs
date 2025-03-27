using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Shared.Navigation;

public interface INavigationService
{
    void Navigate(ViewModelBase viewModel);
}