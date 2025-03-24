using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IncidentApp.Definitions.Base;

public interface IAppDefinition
{
    int OrderIndex { get; }
    bool Enabled { get; }
    void ConfigureServices(IServiceCollection services, HostBuilderContext context);
    Task ConfigureApplication(IHost host);
}