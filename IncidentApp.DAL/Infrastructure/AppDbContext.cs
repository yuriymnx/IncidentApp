using IncidentApp.Core.Domain.Entities;
using IncidentApp.DAL.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IncidentApp.DAL.Infrastructure;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Survey> Surveys { get; set; }
    public DbSet<SurveyQuestion> Questions { get; set; }
    public DbSet<SurveyResponse> Responses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("PostgresConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }
}