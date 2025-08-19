
namespace ProsperDaily.Services;

public interface IDialogService
{
    Task ShowAlertAsync(string title, string message, string cancelButton = "OK");
    Task<bool> ShowConfirmAsync(string title, string message, string acceptButton = "Yes", string cancelButton = "No");
}