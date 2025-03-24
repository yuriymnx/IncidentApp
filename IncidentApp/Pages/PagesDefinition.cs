using IncidentApp.Definitions.Base;
using IncidentApp.Pages.Home;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IncidentApp.Pages;

public class PagesDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        services.AddPage<HomeViewModel>();
    }
}