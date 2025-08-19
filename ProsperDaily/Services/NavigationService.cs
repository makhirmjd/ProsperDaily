namespace ProsperDaily.Services;

public  class NavigationService : INavigationService
{
    private static Page? CurrentPage => Application.Current?.Windows[0]?.Page;
    private static INavigation? Navigation => CurrentPage?.Navigation;

    public async Task PushAsync(Page page)
    {
        if (Navigation is not null)
        {
            await Navigation.PushAsync(page);
        }
    }

    public async Task PopAsync()
    {
        if (Navigation is not null && Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync();
        }
    }

    public async Task PopToRootAsync()
    {
        if (Navigation is not null)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
