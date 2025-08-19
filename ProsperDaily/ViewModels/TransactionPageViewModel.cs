using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProsperDaily.Repositories;
using ProsperDaily.Services;
using ProsperDaily.Shared.Entities;

namespace ProsperDaily.ViewModels;

public partial class TransactionPageViewModel(BaseRepository<Transaction> repository, 
    IDialogService dialogService, INavigationService navigationService) : ObservableObject
{
    [ObservableProperty]
    public Transaction transaction = new();

    [RelayCommand]
    public async Task SaveTransaction()
    {
        if (Transaction.Id == 0)
        {
            await repository.AddAsync(Transaction);
        }
        else
        {
            await repository.UpdateAsync(Transaction);
        }
        await dialogService.ShowAlertAsync("Info", repository.LastOperationStatus.StatusMessage);
        await navigationService.PopToRootAsync();
    }

    [RelayCommand]
    public async Task Cancel() => await navigationService.PopToRootAsync();
}
