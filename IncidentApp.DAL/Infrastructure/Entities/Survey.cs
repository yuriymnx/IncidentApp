using IncidentApp.Domain.Base;

namespace IncidentApp.Domain.Infrastructure.Entities;

public class Survey : Auditable 
{
    public string? Title { get; set; }
    public List<SurveyQuestion>? Questions { get; set; }
}