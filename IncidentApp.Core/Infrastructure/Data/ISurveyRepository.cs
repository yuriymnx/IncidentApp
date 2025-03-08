using IncidentApp.Core.Domain.Entities;

namespace IncidentApp.Core.Infrastructure.Data;

public interface ISurveyRepository
{
    Task<List<Survey>> GetSurveysAsync();
    Task<Survey?> GetSurveyByIdAsync(Guid id);
    Task AddSurveyAsync(Survey survey);
}