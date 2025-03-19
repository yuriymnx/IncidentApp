using Microsoft.EntityFrameworkCore;

namespace IncidentApp.Domain.Infrastructure.Services;

public class ReportService : IReportService
{
    private readonly AppDbContext _context;

    public ReportService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<SurveyDto?> GenerateReportAsync(Guid surveyId)
    {
        var survey = await _context.Surveys.FirstOrDefaultAsync(s => s.Id == surveyId);
        return survey?.ToDto();
    }
}