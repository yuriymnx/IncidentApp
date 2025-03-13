using IncidentApp.Core.Domain.Entities;

namespace IncidentApp.Core.Domain.Interfaces;

public interface IReportService
{
    Task<SurveyDto?> GenerateReportAsync(Guid surveyId);
}