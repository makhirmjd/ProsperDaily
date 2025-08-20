namespace ProsperDaily.Views;

public partial class AppContainerView : TabbedPage
{

    public AppContainerView(DashboardPageView dashboardPageView, StatisticsPageView statisticsPageView)
    {
        NavigationPage navigationPage = new(dashboardPageView)
        {
            Title = "Dashboard"
        };
        Children.Add(navigationPage);
        Children.Add(statisticsPageView);
    }
}
