using IncidentApp.Core.Domain.Enums;
using IncidentApp.Core.Domain.Services.Interfaces;
using IncidentApp.Core.Infrastructure.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace IncidentApp.Core.Domain.Services;


public class ValidationService : IValidationService
{
    private readonly AppDbContext _context;

    public ValidationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ValidateResponseAsync(Guid questionId, string answerJson)
    {
        var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == questionId);
        if (question == null) return false;

        switch (question.Type)
        {
            case QuestionType.Number when !int.TryParse(answerJson, out _):
            case QuestionType.Boolean when !bool.TryParse(answerJson, out _):
                return false;
            case QuestionType.SingleChoice:
            case QuestionType.MultipleChoice:
            {
                var options = JsonSerializer.Deserialize<List<string>>(question.OptionsJson);
                var answers = JsonSerializer.Deserialize<List<string>>(answerJson);
                if (answers.Any(a => !options.Contains(a))) return false;
                break;
            }
            case QuestionType.Text:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return true;
    }
}