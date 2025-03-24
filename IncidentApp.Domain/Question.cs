using IncidentApp.Domain.Base;

namespace IncidentApp.Domain;

public class Question : Identity
{
    public required Guid? SurveyId { get; set; }
    public required Survey? Survey { get; set; }
    public required string? QuestionText { get; set; }
    public required QuestionType Type { get; set; }
    public required string? OptionsJson { get; set; }

    public virtual List<Response>? Responses { get; set; }
}