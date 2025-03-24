using IncidentApp.Domain.Base;

namespace IncidentApp.Domain;

public class Survey : Auditable
{
    public required string? Title { get; set; }
    public List<Question>? Questions { get; set; }
}