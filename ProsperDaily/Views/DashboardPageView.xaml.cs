using ProsperDaily.ViewModels;

namespace ProsperDaily.Views;

public partial class DashboardPageView : ContentPage
{
    private readonly DashboardPageViewModel dashboardPageViewModel;

    public DashboardPageView(DashboardPageViewModel dashboardPageViewModel)
	{
		InitializeComponent();
        this.dashboardPageViewModel = dashboardPageViewModel;
        BindingContext = dashboardPageViewModel;
    }
}