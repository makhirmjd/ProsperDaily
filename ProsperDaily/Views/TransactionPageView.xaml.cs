using ProsperDaily.ViewModels;

namespace ProsperDaily.Views;

public partial class TransactionPageView : ContentPage
{
    private readonly TransactionPageViewModel viewModel;

    public TransactionPageView(TransactionPageViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }
}