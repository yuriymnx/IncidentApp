using IncidentApp.Definitions.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IncidentApp.Shared.Navigation.Bar;

public class NavigationBarDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        services.AddSingleton<NavigationBarViewModel>();
    }
}