using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IncidentApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IncidentApp.Domain;

namespace IncidentApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    [ObservableProperty]
    private ObservableCollection<Survey> _surveys = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(DeleteSurveyCommand))]
    [NotifyCanExecuteChangedFor(nameof(EditSurveyCommand))]
    private Survey? _selectedSurvey;

    public MainViewModel()
    {
    }

    [RelayCommand]
    private async Task LoadSurveysAsync()
    {
    }

    [RelayCommand]
    private async Task CreateSurveyAsync()
    {
    }

    [RelayCommand(CanExecute = nameof(CanDeleteSurveyExecute))]
    private async Task DeleteSurveyAsync()
    {
    }

    private bool CanDeleteSurveyExecute => SelectedSurvey != null;

    [RelayCommand(CanExecute = nameof(CanEditSurveyExecute))]
    private async Task EditSurveyAsync()
    {
    }

    private bool CanEditSurveyExecute => SelectedSurvey != null;
}