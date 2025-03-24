using IncidentApp.Shared.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.Pages;

public static class AddPageExtensions
{
    public static IServiceCollection AddPage<TViewModel>(this IServiceCollection serviceCollection)
        where TViewModel : ViewModelBase
    {
        serviceCollection.AddTransient<TViewModel>();

        return serviceCollection;
    }
}