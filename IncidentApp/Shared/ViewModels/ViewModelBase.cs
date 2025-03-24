using CommunityToolkit.Mvvm.ComponentModel;

namespace IncidentApp.Shared.ViewModels;

public abstract class ViewModelBase : ObservableObject
{
    public virtual void Dispose()
    {
    }
}