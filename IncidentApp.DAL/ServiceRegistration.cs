using IncidentApp.Core.Domain.Interfaces;
using IncidentApp.DAL.Infrastructure;
using IncidentApp.DAL.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.DAL;

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