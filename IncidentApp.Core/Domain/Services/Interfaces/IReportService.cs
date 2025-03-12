using IncidentApp.Core.Domain.Entities;

namespace IncidentApp.Core.Domain.Services.Interfaces;

public interface IReportService
{
    Task<Survey> GenerateReportAsync(Guid surveyId);
}