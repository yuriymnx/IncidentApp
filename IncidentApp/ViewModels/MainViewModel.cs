using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IncidentApp.Core.Domain.Entities;
using IncidentApp.Core.Domain.Services.Interfaces;
using IncidentApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ISurveyService _surveyService;

    [ObservableProperty]
    private ObservableCollection<Survey> _surveys = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(DeleteSurveyCommand))]
    [NotifyCanExecuteChangedFor(nameof(EditSurveyCommand))]
    private Survey? _selectedSurvey;

    public MainViewModel(ISurveyService surveyService)
    {
        _surveyService = surveyService;
    }

    [RelayCommand]
    private async Task LoadSurveysAsync()
    {
        var surveys = await _surveyService.GetAllSurveysAsync();
        Surveys = new ObservableCollection<Survey>(surveys);
    }

    [RelayCommand]
    private async Task CreateSurveyAsync()
    {
        var newSurvey = new Survey { Title = "Новый опрос" };
        var surveyId = await _surveyService.CreateSurveyAsync(newSurvey);
        Surveys.Add(new Survey { Id = surveyId, Title = newSurvey.Title });
    }

    [RelayCommand(CanExecute = nameof(CanDeleteSurveyExecute))]
    private async Task DeleteSurveyAsync()
    {
        if (SelectedSurvey != null)
        {
            await _surveyService.DeleteSurveyAsync(SelectedSurvey.Id);
            Surveys.Remove(SelectedSurvey);
        }
    }

    private bool CanDeleteSurveyExecute => SelectedSurvey != null;

    [RelayCommand(CanExecute = nameof(CanEditSurveyExecute))]
    private async Task EditSurveyAsync()
    {
        if (SelectedSurvey != null)
        {
            // Заглушка: можно добавить логику редактирования
            SelectedSurvey.Title = "Новый опрос...";
            await _surveyService.UpdateSurveyAsync(SelectedSurvey);
            Surveys[Surveys.IndexOf(SelectedSurvey)] = SelectedSurvey;
        }
    }

    private bool CanEditSurveyExecute => SelectedSurvey != null;
}