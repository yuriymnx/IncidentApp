using IncidentApp.Core.Domain.Interfaces;

namespace IncidentApp.DAL.Infrastructure.Services;


public class ValidationService : IValidationService
{
    private readonly AppDbContext _context;

    public ValidationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ValidateResponseAsync(Guid questionId, string answerJson)
    {
        return await Task.FromResult(true);
    }
}