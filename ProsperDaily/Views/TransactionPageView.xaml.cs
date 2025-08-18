using ProsperDaily.ViewModels;

namespace ProsperDaily.Views;

public partial class TransactionPageView : ContentPage
{
    private readonly TransactionPageViewModel transactionPageViewModel;

    public TransactionPageView(TransactionPageViewModel transactionPageViewModel)
	{
		InitializeComponent();
        this.transactionPageViewModel = transactionPageViewModel;
        BindingContext = transactionPageViewModel;
    }
}