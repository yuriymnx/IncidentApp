using Avalonia.Controls;
using IncidentApp.Views.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IncidentApp.Views;

public partial class MainWindow : Window
{
    public MainWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        
        var mainView = serviceProvider.GetRequiredService<MainView>();
        Content = mainView;
    }
}