


namespace ProsperDaily.Services;

public interface INavigationService
{
    Task PopAsync(bool animated = true);
    Task PopToRootAsync(bool animated = true);
    Task PushAsync<TPage>(object? parameter = null, bool animated = true) where TPage : Page;
    Task ShowModalAsync<TPage>(object? parameter = null, bool animated = true) where TPage : Page;
}