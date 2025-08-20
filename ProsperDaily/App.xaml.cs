using ProsperDaily.ViewModels;
using ProsperDaily.Views;

namespace ProsperDaily
{
    public partial class App : Application
    {
        private readonly DashboardPageView dashboardPageView;

        public App(DashboardPageView dashboardPageView)
        {
            InitializeComponent();
            this.dashboardPageView = dashboardPageView;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(dashboardPageView));
            //return new Window(new TransactionPageView(transactionPageViewModel));
            //return new Window(new StatisticsPageView(statisticsPageViewModel));
        }
    }
}