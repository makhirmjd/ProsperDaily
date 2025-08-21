using ProsperDaily.ViewModels;

namespace ProsperDaily.Views;

public partial class DashboardPageView : ContentPage
{
    private readonly DashboardPageViewModel viewModel;

    public DashboardPageView(DashboardPageViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
        viewModel.Owner = this;
    }

    protected override async void OnAppearing()
    {
        await viewModel.RefreshData();
    }
}