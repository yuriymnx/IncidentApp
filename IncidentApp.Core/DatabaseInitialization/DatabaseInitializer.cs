using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IncidentApp.Infrastructure.DatabaseInitialization;

public partial class DatabaseInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DatabaseInitializer> _logger;
    private readonly IServiceScope _scope;
    private readonly string _dataPath;

    public DatabaseInitializer(IServiceProvider serviceProvider, string dataPath)
    {
        _dataPath = dataPath;
        _scope = serviceProvider.CreateScope();
        _context = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        _logger = _scope.ServiceProvider.GetRequiredService<ILogger<DatabaseInitializer>>();
    }

}