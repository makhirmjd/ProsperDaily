namespace ProsperDaily.Services;

public  class NavigationService(IServiceProvider services, IPageResolver resolver) : INavigationService
{
    private static INavigation Navigation => Shell.Current?.Navigation
        ?? Application.Current?.Windows[0]?.Navigation
        ?? throw new InvalidOperationException("No navigation stack available.");

    public async Task PushAsync<TViewModel>(object? parameter = default, bool animated = true)
        => await Navigation.PushAsync(CreatePage<TViewModel>(parameter), animated);

    public Task PopAsync(bool animated = true) => Navigation.PopAsync(animated);
    public Task PopToRootAsync(bool animated = true) => Navigation.PopToRootAsync(animated);

    public async Task ShowModalAsync<TViewModel>(object? parameter = default, bool animated = true)
        => await Navigation.PushModalAsync(CreatePage<TViewModel>(parameter), animated);

    private Page CreatePage<TViewModel>(object? parameter)
    {
        Page page = resolver.ResolvePageForViewModel(typeof(TViewModel), services);

        if (parameter is not null && page is IQueryAttributable queryAware)
        {
            IDictionary<string, object> dict =
                parameter as IDictionary<string, object> ?? new Dictionary<string, object> { ["param"] = parameter };
            queryAware.ApplyQueryAttributes(dict);
        }
        return page;
    }
}
