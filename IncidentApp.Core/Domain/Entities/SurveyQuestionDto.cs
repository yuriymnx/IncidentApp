// ReSharper disable PropertyCanBeMadeInitOnly.Global

using IncidentApp.Infrastructure.Domain.Enums;

namespace IncidentApp.Infrastructure.Domain.Entities;

public class SurveyQuestionDto
{
    public Guid Id { get; set; }
    public SurveyDto? Survey { get; set; }
    public string? QuestionText { get; set; }
    public QuestionType? Type { get; set; }
    public string? OptionsJson { get; set; }
}