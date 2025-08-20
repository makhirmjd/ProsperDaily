using ProsperDaily.ViewModels;
using System.Threading.Tasks;

namespace ProsperDaily.Views;

public partial class StatisticsPageView : ContentPage
{
    private readonly StatisticsPageViewModel viewModel;

    public StatisticsPageView(StatisticsPageViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        await viewModel.GetTransactionsSummary();
    }
}