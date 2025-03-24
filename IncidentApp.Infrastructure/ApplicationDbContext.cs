using IncidentApp.Domain;
using IncidentApp.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IncidentApp.Infrastructure;

public class ApplicationDbContext : DbContextBase
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Survey> Surveys { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Response> Responses{ get; set; } = null!;
}

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=incident_db;Username=postgres;Password=yourpassword");
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}