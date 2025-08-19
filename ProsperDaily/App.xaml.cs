using ProsperDaily.ViewModels;
using ProsperDaily.Views;

namespace ProsperDaily
{
    public partial class App : Application
    {
        private readonly DashboardPageViewModel dashboardPageViewModel;
        private readonly TransactionPageViewModel transactionPageViewModel;
        private readonly StatisticsPageViewModel statisticsPageViewModel;

        public App(DashboardPageViewModel dashboardPageViewModel, 
            TransactionPageViewModel transactionPageViewModel,
            StatisticsPageViewModel statisticsPageViewModel)
        {
            InitializeComponent();
            this.dashboardPageViewModel = dashboardPageViewModel;
            this.transactionPageViewModel = transactionPageViewModel;
            this.statisticsPageViewModel = statisticsPageViewModel;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new DashboardPageView(dashboardPageViewModel));
            //return new Window(new TransactionPageView(transactionPageViewModel));
            return new Window(new StatisticsPageView(statisticsPageViewModel));
        }
    }
}