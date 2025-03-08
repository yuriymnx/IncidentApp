using IncidentApp.ViewModels;
using IncidentApp.Views;
using IncidentApp.Views.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp;

public static class ServiceRegistration
{
    public static void AddViewServices(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddTransient<MainView>();
        services.AddTransient<MainWindow>();
    }
}