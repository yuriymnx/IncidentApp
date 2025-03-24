using IncidentApp.Definitions.Base;
using IncidentApp.Shared.Navigation.Modal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IncidentApp.Shared.Navigation;

public class NavigationDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        services.AddSingleton<NavigationMediator>();
        services.AddSingleton<ModalNavigationMediator>();
        services.AddSingleton<CloseModalNavigationService>();
    }
}