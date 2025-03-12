using IncidentApp.Core.Domain.Entities;

namespace IncidentApp.Core.Domain.Services.Interfaces;

public interface ISurveyService
{
    Task<Guid> CreateSurveyAsync(Survey surveyDto);

    Task<Survey?> GetSurveyAsync(Guid id);

    Task<List<Survey>> GetAllSurveysAsync();

    Task AddQuestionAsync(Guid surveyId, SurveyQuestion questionDto);

    Task DeleteSurveyAsync(Guid id);

    Task UpdateSurveyAsync(Survey selectedSurvey);
}