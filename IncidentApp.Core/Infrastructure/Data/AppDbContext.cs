using IncidentApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IncidentApp.Core.Infrastructure.Data;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public AppDbContext()
    {
        _configuration = new ConfigurationBuilder().Build();
    }

    public DbSet<Survey> Surveys { get; set; }
    public DbSet<SurveyQuestion> Questions { get; set; }
    public DbSet<SurveyResponse> Responses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("PostgresConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = "Host=localhost;Port=5432;Database=incident_db;Username=postgres;Password=yourpassword";
        }
        optionsBuilder.UseNpgsql(connectionString);
    }
}