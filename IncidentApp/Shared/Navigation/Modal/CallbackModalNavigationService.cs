using System;
using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Shared.Navigation.Modal;

public class CallbackModalNavigationService<TParameter, TViewModel> : ICallbackNavigationService<TParameter> where TViewModel : ViewModelBase, ICallbackViewModel<TParameter>
{
    private readonly INavigationMediator _navigationMediator;
    private readonly CreateViewModel<Action<TParameter>, TViewModel> _createViewModel;
    public CallbackModalNavigationService(INavigationMediator navigationMediator, CreateViewModel<Action<TParameter>, TViewModel> createViewModel)
    {
        _navigationMediator = navigationMediator;
        _createViewModel = createViewModel;
    }

    public void Navigate(Action<TParameter> parameter)
    {
        _navigationMediator.CurrentViewModel = _createViewModel(parameter);
    }
}

public class ParameterCallbackModalNavigationService<TParameter, T, TViewModel> : IParameterCallbackNavigationService<TParameter, T> where TViewModel : ViewModelBase, ICallbackViewModel<TParameter, T>
{
    private readonly INavigationMediator _navigationMediator;
    private readonly CreateViewModel<Action<TParameter>, T, TViewModel> _createViewModel;

    public ParameterCallbackModalNavigationService(INavigationMediator navigationMediator, CreateViewModel<Action<TParameter>, T, TViewModel> createViewModel)
    {
        _navigationMediator = navigationMediator;
        _createViewModel = createViewModel;
    }

    public void Navigate(Action<TParameter> parameter, T parameter2)
    {
        _navigationMediator.CurrentViewModel = _createViewModel(parameter, parameter2);
    }
}