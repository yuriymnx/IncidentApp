using Calabonga.UnitOfWork;
using IncidentApp.Domain.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IncidentApp.Infrastructure.Base;

public abstract class DbContextBase : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    private const string DefaultUserName = "Anonymous";
    private const string CreatedAt = nameof(CreatedAt);
    private const string CreatedBy = nameof(CreatedBy);
    private const string UpdatedAt = nameof(UpdatedAt);
    private const string UpdatedBy = nameof(UpdatedBy);

    public DbContextBase(DbContextOptions options) : base(options) { }

    public SaveChangesResult LastSaveChangesResult { get; } = new();

    public override int SaveChanges() => SaveChanges(true);

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        try
        {
            DbSaveChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        catch (Exception exception)
        {
            LastSaveChangesResult.Exception = exception;
            return 0;
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new()) => SaveChangesAsync(true, cancellationToken);

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new())
    {
        try
        {
            DbSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        catch (Exception exception)
        {
            LastSaveChangesResult.Exception = exception;
            return Task.FromResult(0);
        }
    }

    private void DbSaveChanges()
    {
        SaveCreated();
        SaveUpdated();
    }

    private void SaveCreated()
    {
        var createdEntries = ChangeTracker
            .Entries()
            .Where(entry => entry.State == EntityState.Added);

        foreach (var entry in createdEntries)
        {
            if (entry.Entity is IAuditable)
            {
                var userName = entry.Property(CreatedBy).CurrentValue ?? DefaultUserName;
                var creationDate = DateTime.UtcNow;

                if (entry.Property(CreatedAt).CurrentValue == null || ((DateTime)entry.Property(CreatedAt).CurrentValue!).Year < 1950)
                    entry.Property(CreatedAt).CurrentValue = creationDate;

                if (entry.Property(UpdatedAt).CurrentValue == null || ((DateTime)entry.Property(UpdatedAt).CurrentValue!).Year < 1950)
                    entry.Property(UpdatedAt).CurrentValue = creationDate;

                entry.Property(CreatedBy).CurrentValue = userName;
                entry.Property(UpdatedBy).CurrentValue = userName;
            }

            LastSaveChangesResult.AddMessage($"ChangeTracker has new entities: {entry.Entity.GetType()}");
        }
    }

    private void SaveUpdated()
    {
        var updatedEntries = ChangeTracker
            .Entries()
            .Where(entry => entry.State == EntityState.Modified);

        foreach (var entry in updatedEntries)
        {
            if (entry.Entity is IAuditable)
            {
                entry.Property(UpdatedBy).CurrentValue ??= DefaultUserName;
                entry.Property(UpdatedAt).CurrentValue = DateTime.UtcNow;
            }

            LastSaveChangesResult.AddMessage($"ChangeTracker has modified entities: {entry.Entity.GetType()}");
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}