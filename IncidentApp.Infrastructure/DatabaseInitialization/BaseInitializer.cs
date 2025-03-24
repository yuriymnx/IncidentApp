using IncidentApp.Domain;
using IncidentApp.Infrastructure.Utils;

namespace IncidentApp.Infrastructure.DatabaseInitialization;

public partial class DatabaseInitializer
{
    public async Task SeedAll()
    {
        if (_context.Surveys.Any())
            return;

        var surveys = new List<Survey>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Опрос 1",
                Questions = new List<Question>()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Опрос 2",
                Questions = new List<Question>()
            }
        };

        await _context.Surveys.AddRangeAsync(surveys);

        var questions = new List<Question>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Survey = surveys[0],
                SurveyId = surveys[0].Id,
                Type = QuestionType.Boolean,
                QuestionText = "Текст вопроса 1.1",
                Responses = new List<Response>(),
                OptionsJson = QuestionType.Boolean.Options<bool>(),
            },
            new()
            {
                Id = Guid.NewGuid(),
                Survey = surveys[0],
                SurveyId = surveys[0].Id,
                Type = QuestionType.Number,
                QuestionText = "Текст вопроса 1.2",
                Responses = new List<Response>(),
                OptionsJson = QuestionType.Number.Options(1,2,3,4,5),
            },
            new()
            {
                Id = Guid.NewGuid(),
                Survey = surveys[0],
                SurveyId = surveys[0].Id,
                Type = QuestionType.Text,
                QuestionText = "Текст вопроса 1.3",
                Responses = new List<Response>(),
                OptionsJson = QuestionType.Text.Options("Ответ 1", "Ответ 2", "Ответ 3", "Ответ 4"),
            },
            new()
            {
                Id = Guid.NewGuid(),
                Survey = surveys[1],
                SurveyId = surveys[1].Id,
                Type = QuestionType.Text,
                QuestionText = "Текст вопроса 2.1",
                Responses = new List<Response>(),
                OptionsJson = QuestionType.Text.Options("Ответ 1", "Ответ 2", "Ответ 3", "Ответ 4"),
            },
        };

        await _context.Questions.AddRangeAsync(questions);

        var responses = new List<Response>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Question = questions[0],
                QuestionId = questions[0].Id,
                Answer = questions[0].Answer(true),
            },
            new()
            {
                Id = Guid.NewGuid(),
                Question = questions[1],
                QuestionId = questions[1].Id,
                Answer = questions[1].Answer(12),
            },
            new()
            {
                Id = Guid.NewGuid(),
                Question = questions[1],
                QuestionId = questions[1].Id,
                Answer = questions[1].Answer(5.2),
            },
            new()
            {
                Id = Guid.NewGuid(),
                Question = questions[2],
                QuestionId = questions[2].Id,
                Answer = questions[2].Answer("Ответ 1"),
            },
            new()
            {
                Id = Guid.NewGuid(),
                Question = questions[3],
                QuestionId = questions[3].Id,
                Answer = questions[3].Answer("Ответ 3"),
            },
        };

        await _context.Responses.AddRangeAsync(responses);

        await _context.SaveChangesAsync();

    }


}