using ProsperDaily.ViewModels;

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
}