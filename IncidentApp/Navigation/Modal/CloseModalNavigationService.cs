namespace IncidentApp.Navigation.Modal;

public class CloseModalNavigationService : INavigationService
{
    private readonly ModalNavigationMediator _navigationMediator;

    public CloseModalNavigationService(ModalNavigationMediator navigationMediator)
    {
        _navigationMediator = navigationMediator;
    }

    public void Navigate()
    {
        _navigationMediator.Close();
    }
}