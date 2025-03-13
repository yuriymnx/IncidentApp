using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IncidentApp.Core.Domain.Entities;
using IncidentApp.Core.Domain.Interfaces;
using IncidentApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IncidentApp.Core.Domain.Enums;

namespace IncidentApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ISurveyService _surveyService;

    [ObservableProperty]
    private ObservableCollection<SurveyDto> _surveys = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(DeleteSurveyCommand))]
    [NotifyCanExecuteChangedFor(nameof(EditSurveyCommand))]
    private SurveyDto? _selectedSurvey;

    public MainViewModel(ISurveyService surveyService)
    {
        _surveyService = surveyService;
    }

    public MainViewModel()
    {
        _surveyService = new DummySurveyService();
    }

    [RelayCommand]
    private async Task LoadSurveysAsync()
    {
        var surveys = await _surveyService.GetAllSurveysAsync();
        Surveys = new ObservableCollection<SurveyDto>(surveys);
    }

    [RelayCommand]
    private async Task CreateSurveyAsync()
    {
        var newSurvey = new SurveyDto { Id = Guid.NewGuid(), Title = "Новый опрос" };
        var surveyId = await _surveyService.CreateSurveyAsync(newSurvey);
        Surveys.Add(new SurveyDto { Id = surveyId, Title = newSurvey.Title });
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

public class DummySurveyService : ISurveyService
{
    public Task<Guid> CreateSurveyAsync(SurveyDto surveyDto)
    {
        return Task.FromResult(new Guid());
    }

    public Task<List<SurveyDto>> GetAllSurveysAsync()
    {
        var survey = new SurveyDto()
        {
            Id = new Guid(),
            Title = "TEXT",
        };
        survey.Questions = new List<SurveyQuestionDto>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                QuestionText = "QUESTION_TEXT_1",
                Type = QuestionType.Number,
                OptionsJson = "OPTIONS_JSON_1",
                Survey = survey
            },
            new()
            {
                Id = Guid.NewGuid(),
                QuestionText = "QUESTION_TEXT_2",
                Type = QuestionType.Number,
                OptionsJson = "OPTIONS_JSON_2",
                Survey = survey
            }
        };
        return Task.FromResult(new List<SurveyDto> { survey });
    }

    public Task<bool> DeleteSurveyAsync(Guid id)
    {
        return Task.FromResult(true);
    }

    public Task<bool> UpdateSurveyAsync(SurveyDto selectedSurvey)
    {
        return Task.FromResult(true);
    }
}