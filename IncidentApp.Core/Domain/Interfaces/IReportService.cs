using IncidentApp.Infrastructure.Domain.Entities;

namespace IncidentApp.Infrastructure.Domain.Interfaces;

public interface IReportService
{
    Task<SurveyDto?> GenerateReportAsync(Guid surveyId);
}