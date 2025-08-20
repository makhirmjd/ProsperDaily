using ProsperDaily.ViewModels;

namespace ProsperDaily.Views;

public partial class TransactionPageView : ContentPage
{
    private readonly TransactionPageViewModel viewModel;

    public TransactionPageView(TransactionPageViewModel viewModel)
	{
		InitializeComponent();
        viewModel.Owner = this; 
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }
}