using Avalonia.Controls;

namespace IncidentApp.Navigation.Bar;

public partial class NavigationBarView : UserControl
{
    public NavigationBarView()
    {
        // ј’“”Ќ√, не работает! а с чего бы работало)
        // нужен ресерч про этот дебильный DI в Avalonia (((
        //DataContext = App.Current.ServiceProvider.GetRequiredService<NavigationBarViewModel>();

        InitializeComponent();
    }
}