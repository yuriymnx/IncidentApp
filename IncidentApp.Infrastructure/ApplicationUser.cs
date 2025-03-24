using Microsoft.AspNetCore.Identity;

namespace IncidentApp.Infrastructure;

public class ApplicationUser : IdentityUser<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public virtual List<ApplicationRole>? Roles { get; set; }
}