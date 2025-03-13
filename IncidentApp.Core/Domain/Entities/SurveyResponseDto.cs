// ReSharper disable PropertyCanBeMadeInitOnly.Global
namespace IncidentApp.Core.Domain.Entities;

public class SurveyResponseDto
{
    public Guid Id { get; set; }
    public SurveyQuestionDto? Question { get; set; }
    public string? AnswerJson { get; set; }
    public DateTime? AnsweredAt { get; set; }
}