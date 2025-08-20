

namespace ProsperDaily.Services;

public interface INavigationService
{
    Task PopAsync(bool animated = true);
    Task PopToRootAsync(bool animated = true);
    Task PushAsync<TViewModel>(object? parameter = null, bool animated = true);
    Task ShowModalAsync<TViewModel>(object? parameter = null, bool animated = true);
}