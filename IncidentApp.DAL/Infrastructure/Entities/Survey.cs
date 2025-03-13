// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global
using IncidentApp.Core.Domain.Entities;
using IncidentApp.DAL.Extensions;

namespace IncidentApp.DAL.Infrastructure.Entities;

public class Survey
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<SurveyQuestion>? Questions { get; set; }

    private Survey()
    {
    }

    public SurveyDto ToDto()
    {
        return new SurveyDto()
        {
            Id = Id,
            Title = Title,
            Questions = Questions?.Select(x => x.ToDto()).ToList(),
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
        };
    }

    public static Survey FromDto(SurveyDto dto)
    {
        return new Survey()
        {
            Id = dto.Id,
            Title = dto.Title,
            Questions = dto.Questions?.Select(x => x.ToEntity()).ToList(),
            CreatedAt = dto.CreatedAt ?? DateTime.UtcNow,
            UpdatedAt = dto.UpdatedAt ?? DateTime.UtcNow,
        };
    }

    public static Survey Create(Guid id, string title, IEnumerable<SurveyQuestionDto> questions, DateTime? createdAt = null, DateTime? updatedAt = null)
    {
        return new Survey()
        {
            Id = id,
            Title = title,
            Questions = questions.Select(x => x.ToEntity()).ToList(),
            CreatedAt = createdAt ?? DateTime.UtcNow,
            UpdatedAt = updatedAt ?? DateTime.UtcNow,
        };
    }
}