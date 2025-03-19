using System.Text.Json;
using IncidentApp.Domain;

namespace IncidentApp.Infrastructure.Utils;

public static class AnswerHelper
{
    public static string Answer<T>(this Question question, T answer) => Answer(question.Type, answer);

    public static string Answer<T>(this QuestionType type, T answer)
    {
        return JsonSerializer.Serialize(new Dictionary<string, object?>
        {
            {
                type.ToString(),
                type.ResponseType().Contains(typeof(T)) ? answer : null
            }
        });
    }

    public static string Options<T>(this QuestionType type, params T[]? options)
    {
        return JsonSerializer.Serialize(new Dictionary<string, object?>
        {
            {
                type.ToString(),
                options?.Length > 0 ? options : typeof(T).GetDefaults()
            }
        });
    }
}