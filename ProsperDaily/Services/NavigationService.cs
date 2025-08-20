namespace ProsperDaily.Services;

public  class NavigationService(IServiceProvider provider): INavigationService
{
    private static INavigation Navigation =>
    (Application.Current?.Windows.Count > 0
        ? Application.Current.Windows[0].Page as NavigationPage
        : null)?.Navigation
    ?? throw new InvalidOperationException("No navigation context available");

    public async Task PushAsync<TPage>(object? parameter = default, bool animated = true) where TPage : Page
        => await Navigation.PushAsync(ApplyQuery(provider.GetRequiredService<TPage>(), parameter), animated);

    public Task PopAsync(bool animated = true) => Navigation.PopAsync(animated);
    public Task PopToRootAsync(bool animated = true) => Navigation.PopToRootAsync(animated);

    public async Task ShowModalAsync<TPage>(object? parameter = default, bool animated = true) where TPage : Page
        => await Navigation.PushModalAsync(ApplyQuery(provider.GetRequiredService<TPage>(), parameter), animated);

    private static Page ApplyQuery(Page page, object? parameter)
    {
        if (parameter is not null && page is IQueryAttributable queryAware)
        {
            IDictionary<string, object> dict =
                parameter as IDictionary<string, object> ?? new Dictionary<string, object> { ["param"] = parameter };
            queryAware.ApplyQueryAttributes(dict);
        }
        return page;
    }
}
