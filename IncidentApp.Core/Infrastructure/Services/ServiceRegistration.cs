using IncidentApp.Core.Domain.Services.Interfaces;
using IncidentApp.Core.Domain.Services;
using IncidentApp.Core.Infrastructure.Data;
using IncidentApp.Core.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.Core.Infrastructure.Services;

public static class ServiceRegistration
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();

        services.AddSingleton<IDataProviderService, DataProviderService>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<ISurveyService, SurveyService>();
    }
}