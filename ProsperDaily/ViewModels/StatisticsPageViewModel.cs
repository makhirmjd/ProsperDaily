using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ProsperDaily.Data;
using ProsperDaily.Models;
using ProsperDaily.Repositories;
using ProsperDaily.Shared.Entities;
using System.Collections.ObjectModel;

namespace ProsperDaily.ViewModels;

public partial class StatisticsPageViewModel(BaseRepository<Transaction> repository) : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<TransactionsSummary> summary;
    [ObservableProperty]
    private ObservableCollection<Transaction> spendingList;

    public async Task GetTransactionsSummary()
    {
        List<Transaction> data = await repository.GetAllAsync();
        IEnumerable<IGrouping<DateTime, Transaction>> groupedTransactions = data.GroupBy(x => x.TransactionDate.Date);
        List<TransactionsSummary> result = [.. groupedTransactions.Select(g => new TransactionsSummary
        {
            TransactionsDate = g.Key,
            TransactionsTotal = g.Sum(t => t.IsIncome ? t.Amount : -t.Amount),
            ShownDate = g.Key.ToString("MM/dd")
        }).OrderBy(x => x.TransactionsDate)];
        Summary = new(result);
        SpendingList = [.. data.Where(t => !t.IsIncome).OrderBy(t => t.TransactionDate)];
    }
}
