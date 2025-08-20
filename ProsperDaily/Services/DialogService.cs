namespace ProsperDaily.Services;

public class DialogService : IDialogService
{
    private static Page? Page => Shell.Current?.Window?.Page
        ?? Application.Current?.Windows[0]?.Page;

    public Task<bool> ConfirmAsync(string title, string message, string accept = "OK", string cancel = "Cancel")
        => Page?.DisplayAlert(title, message, accept, cancel) ?? Task.FromResult(false);

    public Task AlertAsync(string title, string message, string cancel = "OK")
        => Page?.DisplayAlert(title, message, cancel) ?? Task.CompletedTask;
}
