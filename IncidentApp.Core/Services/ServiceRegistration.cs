using IncidentApp.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.Core.Services;

public static class ServiceRegistration
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<IDataProviderService, DataProviderService>();
    }
}