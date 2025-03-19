using IncidentApp.Domain.Infrastructure;
using IncidentApp.Domain.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.Domain;

public static class ServiceRegistration
{
    public static void AddDalServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        
        services.AddScoped<IValidationService, ValidationService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<ISurveyService, SurveyService>();
    }
}