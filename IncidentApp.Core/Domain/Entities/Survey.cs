namespace IncidentApp.Core.Domain.Entities;

public class Survey
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<SurveyQuestion> Questions { get; set; } = new();
}