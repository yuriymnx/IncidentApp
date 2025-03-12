namespace IncidentApp.Core.Domain.Services.Interfaces;

public interface IValidationService
{
    Task<bool> ValidateResponseAsync(Guid questionId, string answerJson);
}