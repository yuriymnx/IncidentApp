using IncidentApp.Core.Domain.Enums;

namespace IncidentApp.Core.Domain.Entities;

public class SurveyQuestion
{
    public Guid Id { get; set; }
    public Guid SurveyId { get; set; }
    public Survey Survey { get; set; }
    public string? QuestionText { get; set; }
    public QuestionType Type { get; set; }
    public string? OptionsJson { get; set; } // JSON-строка с вариантами ответов (если есть)
}