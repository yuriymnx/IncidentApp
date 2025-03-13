// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global
using IncidentApp.Core.Domain.Entities;
using IncidentApp.Core.Domain.Enums;
using IncidentApp.DAL.Extensions;

namespace IncidentApp.DAL.Infrastructure.Entities;

public class SurveyQuestion
{
    public Guid Id { get; set; }
    public Survey? Survey { get; set; }
    public string? QuestionText { get; set; }
    public QuestionType? Type { get; set; }
    public string? OptionsJson { get; set; }

    private SurveyQuestion()
    {
    }

    public static SurveyQuestion FromDto(SurveyQuestionDto dto)
    {
        return new SurveyQuestion()
        {
            Id = dto.Id,
            Survey = dto.Survey?.ToEntity(),
            QuestionText = dto.QuestionText,
            Type = dto.Type,
            OptionsJson = dto.OptionsJson,
        };
    }

    public static SurveyQuestion Create(Guid id, SurveyDto survey, string questionText, QuestionType type, string? optionsJson)
    {
        return new SurveyQuestion()
        {
            Id = id,
            Survey = survey.ToEntity(),
            QuestionText = questionText,
            Type = type,
            OptionsJson = optionsJson,
        };
    }

    public SurveyQuestionDto ToDto()
    {
        return new SurveyQuestionDto()
        {
            Id = Id,
            Survey = Survey?.ToDto(),
            QuestionText = QuestionText,
            Type = Type,
            OptionsJson = OptionsJson,
        };
    }
}