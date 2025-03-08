using IncidentApp.Core.Infrastructure.Data;
using IncidentApp.Core.Infrastructure.Services;
using IncidentApp.Core.Infrastructure.Services.Interfaces;
using IncidentApp.ViewModels.Base;

namespace IncidentApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IDataProviderService _providerService;

    public MainViewModel(IDataProviderService dataProviderService)
    {
        _providerService = dataProviderService;
    }

    public string Text => _providerService.Text;
}