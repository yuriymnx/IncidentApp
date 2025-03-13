// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global
using IncidentApp.Core.Domain.Entities;
using IncidentApp.DAL.Extensions;

namespace IncidentApp.DAL.Infrastructure.Entities;

public class SurveyResponse
{
    public Guid Id { get; set; }
    public SurveyQuestion? Question { get; set; }
    public string? AnswerJson { get; set; }
    public DateTime AnsweredAt { get; set; }

    private SurveyResponse(){}

    public static SurveyResponse FromDto(SurveyResponseDto dto)
    {
        return new SurveyResponse()
        {
            Id = dto.Id,
            Question = dto.Question?.ToEntity(),
            AnswerJson = dto.AnswerJson,
            AnsweredAt = dto.AnsweredAt ?? DateTime.UtcNow,
        };
    }
    public static SurveyResponse Create(Guid id, SurveyQuestionDto? question, string? answerJson, DateTime? answeredAt = null)
    {
        return new SurveyResponse()
        {
            Id = id,
            Question = question?.ToEntity(),
            AnswerJson = answerJson,
            AnsweredAt = answeredAt ?? DateTime.UtcNow,
        };
    }

    public SurveyResponseDto ToDto()
    {
        return new SurveyResponseDto()
        {
            Id = Id,
            Question = Question?.ToDto(),
            AnswerJson = AnswerJson,
            AnsweredAt = AnsweredAt,
        };
    }
}