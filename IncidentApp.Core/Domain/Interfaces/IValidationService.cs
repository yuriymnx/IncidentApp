namespace IncidentApp.Core.Domain.Interfaces;

public interface IValidationService
{
    Task<bool> ValidateResponseAsync(Guid questionId, string answerJson);
}