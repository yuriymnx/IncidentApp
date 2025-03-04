using IncidentApp.Core.Services;
using IncidentApp.Core.Services.Interfaces;
using IncidentApp.ViewModels.Base;

namespace IncidentApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IDataProviderService _providerService;

    public MainViewModel(IDataProviderService dataProviderService)
    {
        _providerService = dataProviderService;
    }

    public MainViewModel() : this(new DataProviderService())
    {
    }

    public string Text => _providerService.Text;
}