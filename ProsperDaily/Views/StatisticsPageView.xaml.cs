using ProsperDaily.ViewModels;

namespace ProsperDaily.Views;

public partial class StatisticsPageView : ContentPage
{
    private readonly StatisticsPageViewModel statisticsPageViewModel;

    public StatisticsPageView(StatisticsPageViewModel statisticsPageViewModel)
	{
		InitializeComponent();
        this.statisticsPageViewModel = statisticsPageViewModel;
        BindingContext = statisticsPageViewModel;
    }
}