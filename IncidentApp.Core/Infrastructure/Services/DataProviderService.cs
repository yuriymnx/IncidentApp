using IncidentApp.Core.Infrastructure.Data;
using IncidentApp.Core.Infrastructure.Services.Interfaces;

namespace IncidentApp.Core.Infrastructure.Services;

public class DataProviderService : IDataProviderService
{
    private readonly AppDbContext _context;

    public DataProviderService(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public string Text
    {
        get
        {
            string? s;
            try
            {
                s = _context.Surveys.Count().ToString();
            }
            catch(Exception exception)
            {
                s = exception.Message;
            }

            return "Text: " + s;
        }
    }
}