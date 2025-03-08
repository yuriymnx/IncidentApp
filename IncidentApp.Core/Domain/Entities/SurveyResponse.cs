namespace IncidentApp.Core.Domain.Entities;

public class SurveyResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public SurveyQuestion Question { get; set; }
    public string AnswerJson { get; set; } // JSON для хранения разных типов ответов
    public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;
}