using IncidentApp.Definitions.Base;
using IncidentApp.Pages.Home;
using IncidentApp.Shared.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IncidentApp.Definitions.Initialization;

public class ApplicationInitializer : AppDefinition
{
    public override int OrderIndex => 100;

    public override async Task ConfigureApplication(IHost host)
    {
        using var scope = host.Services.CreateScope();

        var logger = host.Services.GetRequiredService<ILogger<ApplicationInitializer>>();

        try
        {
            var homeNavigationService = scope.ServiceProvider.GetRequiredService<NavigationService<HomeViewModel>>();
            homeNavigationService.Navigate();
            logger.LogTrace("ApplicationInitializer success");
        }
        catch (Exception exception)
        {
            logger.LogCritical(exception, "Unhandled exception");
        }
    }
}