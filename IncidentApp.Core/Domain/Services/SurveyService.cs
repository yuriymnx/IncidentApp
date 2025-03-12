using IncidentApp.Core.Domain.Entities;
using IncidentApp.Core.Domain.Services.Interfaces;
using IncidentApp.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentApp.Core.Domain.Services;

public class SurveyService : ISurveyService
{
    private readonly AppDbContext _context;

    public SurveyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateSurveyAsync(Survey surveyDto)
    {
        var survey = new Survey
        {
            Id = Guid.NewGuid(),
            Title = surveyDto.Title,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Surveys.Add(survey);
        await _context.SaveChangesAsync();
        return survey.Id;
    }

    public async Task<Survey?> GetSurveyAsync(Guid id)
    {
        var survey = await _context.Surveys.Include(s => s.Questions).FirstOrDefaultAsync(s => s.Id == id);
        if (survey == null) return null;

        return new Survey
        {
            Id = survey.Id,
            Title = survey.Title,
            Questions = survey.Questions.Select(q => new SurveyQuestion
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                Type = q.Type,
                OptionsJson = q.OptionsJson
            }).ToList()
        };
    }

    public async Task<List<Survey>> GetAllSurveysAsync()
    {
        return await _context.Surveys.Select(s => new Survey { Id = s.Id, Title = s.Title }).ToListAsync();
    }

    public async Task AddQuestionAsync(Guid surveyId, SurveyQuestion questionDto)
    {
        var question = new SurveyQuestion
        {
            Id = Guid.NewGuid(),
            SurveyId = surveyId,
            QuestionText = questionDto.QuestionText,
            Type = questionDto.Type,
            OptionsJson = questionDto.OptionsJson
        };

        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSurveyAsync(Guid id)
    {
        var survey = await _context.Surveys.FindAsync(id);
        if (survey != null)
        {
            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateSurveyAsync(Survey selectedSurvey)
    {
        var survey = await _context.Surveys.FindAsync(selectedSurvey.Id);
        if (survey != null)
        {
            survey.Title = selectedSurvey.Title;
            survey.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}