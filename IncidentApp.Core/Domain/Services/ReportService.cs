using IncidentApp.Core.Domain.Entities;
using IncidentApp.Core.Domain.Services.Interfaces;
using IncidentApp.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentApp.Core.Domain.Services;

public class ReportService : IReportService
{
    private readonly AppDbContext _context;

    public ReportService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Survey> GenerateReportAsync(Guid surveyId)
    {
        var survey = await _context.Surveys.Include(s => s.Questions).ThenInclude(q => q.Survey).FirstOrDefaultAsync(s => s.Id == surveyId);
        if (survey == null) return null;

        var report = new Survey()
        {
            Title = survey.Title,
            Questions = new List<SurveyQuestion>(survey.Questions).ToList()
        };

        return report;
    }
}

