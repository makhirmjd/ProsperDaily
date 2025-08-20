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
        private readonly AppContainerView appContainerView;
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;

        public App(AppContainerView appContainerView, IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            InitializeComponent();
            this.appContainerView = appContainerView;
            this.contextFactory = contextFactory;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(appContainerView);
        }

        protected override async void OnStart()
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            await context.Database.MigrateAsync();
        }
    }
}