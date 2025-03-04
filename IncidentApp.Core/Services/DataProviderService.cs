using IncidentApp.Core.Services.Interfaces;

namespace IncidentApp.Core.Services;

public class DataProviderService : IDataProviderService
{
    public string Text => DateTime.Now.ToString("g");
}