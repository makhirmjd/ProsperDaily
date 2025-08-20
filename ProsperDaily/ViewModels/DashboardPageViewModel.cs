using CommunityToolkit.Mvvm.ComponentModel;
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

    [ObservableProperty]
    private ObservableCollection<Transaction> transactions = [];

    [ObservableProperty]
    private decimal totalBalance;
    [ObservableProperty]
    private decimal income;
    [ObservableProperty]
    private decimal expenses;


    public DashboardPageViewModel(BaseRepository<Transaction> repository, 
        INavigationService navigationService)
	{
        this.repository = repository;
        this.navigationService = navigationService;
        _ = RefreshData();
    }

    public async Task RefreshData()
    {
        List<Transaction> transactions = await repository.GetAllAsync();
        Transactions.Clear();
        decimal totalBalance = 0;
        decimal totalIncome = 0;
        decimal totalExpenses = 0;
        foreach (Transaction transaction in transactions.OrderByDescending(t => t.TransactionDate))
        {
            Transactions.Add(transaction);
            if (transaction.IsIncome)
            {
                totalIncome += transaction.Amount;
            }
            else
            {
                totalExpenses += transaction.Amount;
            }
        }
        TotalBalance = totalIncome - totalExpenses;
        Income = totalIncome;
        Expenses = totalExpenses;
    }

    [RelayCommand]
    public async Task AddTransaction()
    {
        await navigationService.PushTabbedNavigationAsync<TransactionPageView>();
    }
}
