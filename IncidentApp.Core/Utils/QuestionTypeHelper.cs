using IncidentApp.Domain;

namespace IncidentApp.Infrastructure.Utils;

public static class QuestionTypeHelper
{
    private static readonly Dictionary<QuestionType, (Type[] ResponseTypes, bool AllowEmpty)> Metadata =
        new()
        {
            { QuestionType.Text, (new[] {typeof(string)}, false) },
            { QuestionType.Number, (new[] {typeof(int), typeof(decimal), typeof(double), typeof(float)}, false) },
            { QuestionType.Boolean, (new[] {typeof(bool)}, false) },
            { QuestionType.SingleChoice, (new[] {typeof(string)}, false) },
            { QuestionType.MultipleChoice, (new[] {typeof(List<string>)}, false) }
        };

    private static readonly Dictionary<Type, object> Defaults = new()
    {
        { typeof(bool), new bool[] { true, false } },
        { typeof(bool?), new bool? [] { true, false, null } }
    };

    public static IEnumerable<Type> ResponseType(this QuestionType questionType) =>
        Metadata.TryGetValue(questionType, out var metadata) ?
            (IEnumerable<Type>)metadata.ResponseTypes :
            throw new ArgumentException($"Неизвестный тип вопроса: {questionType}");

    public static bool AllowEmptyAnswer(this QuestionType questionType) =>
        Metadata.TryGetValue(questionType, out var metadata) && metadata.AllowEmpty;

    public static object? GetDefaults(this Type type) => Defaults.TryGetValue(type, out var value) ? value : null;
}