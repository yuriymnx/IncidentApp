// ReSharper disable PropertyCanBeMadeInitOnly.Global
namespace IncidentApp.Infrastructure.Domain.Entities;

public class SurveyDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<SurveyQuestionDto>? Questions { get; set; } = new();
}