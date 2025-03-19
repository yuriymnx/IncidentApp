// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global

using IncidentApp.Domain.Base;

namespace IncidentApp.Domain.Infrastructure.Entities;

public class SurveyQuestion : Identity
{
    public Survey? Survey { get; set; }
    public string? QuestionText { get; set; }
    public QuestionType? Type { get; set; }
    public string? OptionsJson { get; set; }
}