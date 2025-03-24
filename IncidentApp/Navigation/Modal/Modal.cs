using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace IncidentApp.Navigation.Modal;

public class Modal : ContentControl
{
    public static readonly StyledProperty<bool> IsOpenProperty = AvaloniaProperty.Register<Modal, bool>(nameof(IsOpen), defaultValue: false);

    static Modal()
    {
        IsOpenProperty.Changed.AddClassHandler<Modal>((x, e) => x.OnIsOpenChanged(e));
    }

    public Modal()
    {
        Background = CreateDefaultBackground();
    }

    public bool IsOpen
    {
        get => GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }

    private void OnIsOpenChanged(AvaloniaPropertyChangedEventArgs e)
    {
        // TODO: Логика при изменении IsOpen (например, анимации)
    }

    private static IBrush CreateDefaultBackground()
    {
        return new SolidColorBrush(Colors.Black) { Opacity = 0.3 };
    }
}