using IncidentApp.Domain.Base;

namespace IncidentApp.Domain.Infrastructure.Entities;

public class SurveyResponse : Auditable
{
    public SurveyQuestion? Question { get; set; }
    public string? AnswerJson { get; set; }
    public DateTime AnsweredAt { get; set; }
}