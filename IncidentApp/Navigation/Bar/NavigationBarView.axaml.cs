using Avalonia.Controls;

namespace IncidentApp.Navigation.Bar;

public partial class NavigationBarView : UserControl
{
    public NavigationBarView()
    {
        // ������, �� ��������! � � ���� �� ��������)
        // ����� ������ ��� ���� ��������� DI � Avalonia (((
        //DataContext = App.Current.ServiceProvider.GetRequiredService<NavigationBarViewModel>();

        InitializeComponent();
    }
}