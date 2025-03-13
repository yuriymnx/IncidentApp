using Avalonia.Controls;
using IncidentApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.Views.Controls;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<MainViewModel>();
    }
}