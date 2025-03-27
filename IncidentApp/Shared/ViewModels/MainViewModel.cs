using IncidentApp.Shared.Navigation;
using IncidentApp.Shared.Navigation.Bar;

namespace IncidentApp.Shared.ViewModels;

public sealed class MainViewModel : ViewModelBase
{
    private readonly NavigationMediator _navigationMediator;

    public MainViewModel(
        NavigationMediator navigationMediator,
        NavigationBarViewModel barViewModel)
    {
        _navigationMediator = navigationMediator;

        barViewModel.MainViewModel = this;
        NavigationBarViewModel = barViewModel;

        _navigationMediator.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    public NavigationBarViewModel NavigationBarViewModel { get; }
    public ViewModelBase? CurrentViewModel => _navigationMediator.CurrentViewModel;

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    public override void Dispose()
    {
        _navigationMediator.CurrentViewModelChanged -= OnCurrentViewModelChanged;

        base.Dispose();
    }
}