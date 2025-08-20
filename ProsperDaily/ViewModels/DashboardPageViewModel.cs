using CommunityToolkit.Mvvm.Input;
using ProsperDaily.Repositories;
using ProsperDaily.Services;
using ProsperDaily.Shared.Entities;
using ProsperDaily.Views;
using System.Collections.ObjectModel;

namespace ProsperDaily.ViewModels;

public partial class DashboardPageViewModel : BaseViewModel
{
    private readonly BaseRepository<Transaction> repository;
    private readonly INavigationService navigationService;

    public ObservableCollection<Transaction> Transactions { get; set; } = [];

    public decimal TotalBalance => Transactions.ToList().Sum(x => x.Amount);
    public decimal Income => Transactions.Where(x => x.IsIncome).ToList().Sum(x => x.Amount);
    public decimal Expenses => Transactions.Where(x => !x.IsIncome).ToList().Sum(x => x.Amount);


    public DashboardPageViewModel(BaseRepository<Transaction> repository, 
        INavigationService navigationService)
	{
        this.repository = repository;
        this.navigationService = navigationService;
        _ = FillData();
    }

    private async Task FillData()
    {
        List<Transaction> transactions = await repository.GetAllAsync();
        Transactions = [.. transactions.OrderByDescending(t => t.TransactionDate)];
    }

    [RelayCommand]
    public async Task AddTransaction()
    {
        await navigationService.PushAsync<TransactionPageView>();
    }
}
