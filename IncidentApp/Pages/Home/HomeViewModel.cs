﻿using System;
using IncidentApp.Shared.ViewModels;

namespace IncidentApp.Pages.Home;

public class HomeViewModel : ViewModelBase
{
    public string Username => Environment.UserName;
    
}