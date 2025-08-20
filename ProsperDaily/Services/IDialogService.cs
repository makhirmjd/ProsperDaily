

namespace ProsperDaily.Services;

public interface IDialogService
{
    Task AlertAsync(string title, string message, string cancel = "OK");
    Task<bool> ConfirmAsync(string title, string message, string accept = "OK", string cancel = "Cancel");
}