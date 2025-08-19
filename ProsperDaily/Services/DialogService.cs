namespace ProsperDaily.Services;

public class DialogService : IDialogService
{
    public async Task ShowAlertAsync(string title, string message, string cancelButton = "OK")
    {
        Page? page = Application.Current?.Windows[0]?.Page;
        if ( page is not null)
        {
            await page.DisplayAlert(title, message, cancelButton);
        }
    }

    public async Task<bool> ShowConfirmAsync(string title, string message, string acceptButton = "Yes", string cancelButton = "No")
    {
        Page? page = Application.Current?.Windows[0]?.Page;
        if (page is not null)
        {
            return await page.DisplayAlert(title, message, acceptButton, cancelButton);
        }
        return false;
    }
}
