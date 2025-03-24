using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IncidentApp.Definitions.Base;

public abstract class AppDefinition : IAppDefinition
{
    public virtual int OrderIndex => 0;
    public virtual bool Enabled => true;

    public virtual void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
    }

    public virtual Task ConfigureApplication(IHost host) => Task.CompletedTask;
}