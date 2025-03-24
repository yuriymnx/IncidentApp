using IncidentApp.Domain.Base;

namespace IncidentApp.Domain;

public class Response : Auditable
{
    public Guid? QuestionId { get; set; }
    public Question? Question { get; set; }
    public string? Answer { get; set; }
    public DateTime? AnsweredAt { get; set; }
}