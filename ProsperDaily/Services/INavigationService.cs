
namespace ProsperDaily.Services;

public interface INavigationService
{
    Task PopAsync();
    Task PopToRootAsync();
    Task PushAsync(Page page);
}