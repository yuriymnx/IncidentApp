using IncidentApp.Infrastructure.Domain.Entities;

namespace IncidentApp.Infrastructure.Domain.Interfaces;

public interface ISurveyService
{
    Task<Guid> CreateSurveyAsync(SurveyDto surveyDto);

    Task<List<SurveyDto>> GetAllSurveysAsync();

    Task<bool> DeleteSurveyAsync(Guid id);

    Task<bool> UpdateSurveyAsync(SurveyDto selectedSurvey);
}