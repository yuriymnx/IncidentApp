using IncidentApp.Core.Domain.Entities;
using IncidentApp.Core.Domain.Interfaces;
using IncidentApp.DAL.Extensions;
using IncidentApp.DAL.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncidentApp.DAL.Infrastructure.Services;

public class SurveyService : ISurveyService
{
    private readonly AppDbContext _context;

    public SurveyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateSurveyAsync(SurveyDto dto)
    {
        var survey = Survey.FromDto(dto);
        _context.Surveys.Add(survey);
        await _context.SaveChangesAsync();
        return survey.Id;
    }

    public async Task<List<SurveyDto>> GetAllSurveysAsync()
    {
        return await _context.Surveys.Select(s => s.ToDto()).ToListAsync();
    }

    public async Task<bool> DeleteSurveyAsync(Guid id)
    {
        var survey = await _context.Surveys.FindAsync(id);
        if (survey == null) return false;
        _context.Surveys.Remove(survey);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateSurveyAsync(SurveyDto selectedSurvey)
    {
        var survey = await _context.Surveys.FindAsync(selectedSurvey.Id);
        if (survey == null) return false;
        // TODO: нужен AutoMapper
        survey.Title = selectedSurvey.Title;
        survey.Questions = selectedSurvey.Questions?.Select(x => x.ToEntity()).ToList();
        survey.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;

    }
}