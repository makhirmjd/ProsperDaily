using CommunityToolkit.Mvvm.ComponentModel;

namespace ProsperDaily.Models;

public partial class TransactionsSummary : ObservableObject
{
    [ObservableProperty]
    private DateTime transactionsDate;
    [ObservableProperty]
    private string shownDate;
    [ObservableProperty]
    private decimal transactionsTotal;
}
