using Microsoft.EntityFrameworkCore;
using ProsperDaily.Data;
using ProsperDaily.ViewModels;
using ProsperDaily.Views;

namespace ProsperDaily
{
    public partial class App : Application
    {
        private readonly DashboardPageView dashboardPageView;
        private readonly StatisticsPageView statisticsPageView;
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;

        public App(DashboardPageView dashboardPageView, StatisticsPageView statisticsPageView, IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            InitializeComponent();
            this.dashboardPageView = dashboardPageView;
            this.statisticsPageView = statisticsPageView;
            this.contextFactory = contextFactory;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new NavigationPage(dashboardPageView));
            return new Window(new NavigationPage(statisticsPageView));
        }

        protected override async void OnStart()
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            await context.Database.MigrateAsync();
        }
    }
}