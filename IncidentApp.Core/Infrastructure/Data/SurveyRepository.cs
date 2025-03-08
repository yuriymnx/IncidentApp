using IncidentApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncidentApp.Core.Infrastructure.Data;

public class SurveyRepository : ISurveyRepository
{
    private readonly AppDbContext _context;

    public SurveyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Survey>> GetSurveysAsync()
    {
        return await _context.Surveys.Include(s => s.Questions).ToListAsync();
    }

    public async Task<Survey?> GetSurveyByIdAsync(Guid id)
    {
        return await _context.Surveys.Include(s => s.Questions)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddSurveyAsync(Survey survey)
    {
        _context.Surveys.Add(survey);
        await _context.SaveChangesAsync();
    }
}