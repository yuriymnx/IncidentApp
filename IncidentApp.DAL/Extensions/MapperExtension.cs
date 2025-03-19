using IncidentApp.Domain.Infrastructure.Entities;

namespace IncidentApp.Domain.Extensions;

internal static class MapperExtension
{
    public static SurveyQuestion ToEntity(this SurveyQuestionDto dto) => SurveyQuestion.FromDto(dto);
    public static Survey ToEntity(this SurveyDto dto) => Survey.FromDto(dto);
    public static SurveyResponse ToEntity(this SurveyResponseDto dto) => SurveyResponse.FromDto(dto);
}