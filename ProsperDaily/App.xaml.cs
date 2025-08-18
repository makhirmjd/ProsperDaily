using ProsperDaily.ViewModels;
using ProsperDaily.Views;

namespace ProsperDaily
{
    public partial class App : Application
    {
        private readonly DashboardPageViewModel dashboardPageViewModel;
        private readonly TransactionPageViewModel transactionPageViewModel;

        public App(DashboardPageViewModel dashboardPageViewModel, TransactionPageViewModel transactionPageViewModel)
        {
            InitializeComponent();
            this.dashboardPageViewModel = dashboardPageViewModel;
            this.transactionPageViewModel = transactionPageViewModel;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new DashboardPageView(dashboardPageViewModel));
            return new Window(new TransactionPageView(transactionPageViewModel));
        }
    }
}