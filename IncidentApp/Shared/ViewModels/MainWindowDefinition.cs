using IncidentApp.Definitions.Base;
using IncidentApp.Definitions.Initialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IncidentApp.Shared.ViewModels;

public class MainWindowDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        services.AddSingleton<ApplicationInitializer>();

        services.AddSingleton<MainViewModel>();

        services.AddSingleton<MainWindow>(serviceProvider => new MainWindow
        {
            DataContext = serviceProvider.GetRequiredService<MainViewModel>()
        });
    }
}