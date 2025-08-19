using CommunityToolkit.Mvvm.ComponentModel;
using ProsperDaily.Repositories;
using ProsperDaily.Shared.Entities;
using System.Collections.ObjectModel;

namespace ProsperDaily.ViewModels;

public partial class DashboardPageViewModel : ObservableObject
{
    private readonly BaseRepository<Transaction> repository;

    public ObservableCollection<Transaction> Transactions { get; set; } = [];

    public decimal TotalBalance => Transactions.ToList().Sum(x => x.Amount);
    public decimal Income => Transactions.Where(x => x.IsIncome).ToList().Sum(x => x.Amount);
    public decimal Expenses => Transactions.Where(x => !x.IsIncome).ToList().Sum(x => x.Amount);


    public DashboardPageViewModel(BaseRepository<Transaction> repository)
	{
        this.repository = repository;
        _ = FillData();
    }

    private async Task FillData()
    {
        List<Transaction> transactions = await repository.GetAllAsync();
        Transactions = [.. transactions.OrderByDescending(t => t.TransactionDate)];
    }
}
