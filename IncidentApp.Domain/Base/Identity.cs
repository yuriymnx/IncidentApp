namespace IncidentApp.Domain.Base;

public abstract class Identity : IHaveId
{
    public Guid Id { get; set; }
}