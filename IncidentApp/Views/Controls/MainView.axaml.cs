using Avalonia.Controls;
using IncidentApp.ViewModels;

namespace IncidentApp.Views.Controls;

public partial class MainView : UserControl
{
    public MainView(MainViewModel mainViewModel)
    {
        InitializeComponent();
        DataContext = mainViewModel;
    }
}