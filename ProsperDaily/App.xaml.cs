using ProsperDaily.ViewModels;
using ProsperDaily.Views;

namespace ProsperDaily
{
    public partial class App : Application
    {
        private readonly DashboardPageViewModel dashboardPageViewModel;

        public App(DashboardPageViewModel dashboardPageViewModel)
        {
            InitializeComponent();
            this.dashboardPageViewModel = dashboardPageViewModel;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new DashboardPageView(dashboardPageViewModel));
        }
    }
}