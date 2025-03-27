using IncidentApp.Pages.Home;
using IncidentApp.Shared.Navigation;
using IncidentApp.Shared.Navigation.Bar;
using IncidentApp.Shared.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<NavigationMediator>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<NavigationBarViewModel>();
        services.AddSingleton<NavigationBarView>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<HomeViewModel>();
    }
}