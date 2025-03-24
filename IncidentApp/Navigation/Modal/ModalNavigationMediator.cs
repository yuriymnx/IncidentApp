﻿using System;
using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Navigation.Modal;

public class ModalNavigationMediator : INavigationMediator
{
    private ViewModelBase? _currentViewModel;

    public bool IsOpen => CurrentViewModel != null;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public event Action? CurrentViewModelChanged;

    public void Close()
    {
        CurrentViewModel?.Dispose();
        CurrentViewModel = null;
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}