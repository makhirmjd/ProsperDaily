using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using ProsperDaily.Data;
using ProsperDaily.Repositories;
using ProsperDaily.Services;
using ProsperDaily.Shared.Entities;
using ProsperDaily.Shared.Services;
using ProsperDaily.ViewModels;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;
using System.Globalization;

namespace ProsperDaily;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        SyncfusionLicenseProvider.RegisterLicense("Mzk5NjgzNEAzMzMwMmUzMDJlMzAzYjMzMzAzYkZFNnVTWUVLKzIyZm9CZEV3N0VqTStuMUg0c0krQWRUQk8xdG9iVC9oL2s9");
        ConfigureDatabaseService(builder.Services);
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("LibreFranklin-Regular.ttf", "Strong");
                fonts.AddFont("Roboto-Black.ttf", "Regular");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        ConfigureCulture();
        ConfigureServices(builder.Services);

        return builder.Build();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddScoped<BaseRepository<Transaction>>();
        services.AddScoped<DashboardPageViewModel>();
        services.AddScoped<TransactionPageViewModel>();
        services.AddScoped<StatisticsPageViewModel>();
    }

    private static void ConfigureDatabaseService(IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite($"Filename={DatabasePath}"));
        using AsyncServiceScope scope = services.BuildServiceProvider().CreateAsyncScope();
        ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }

    private static void ConfigureCulture()
    {
        CultureInfo.DefaultThreadCurrentCulture = new("en-NG");
        CultureInfo.DefaultThreadCurrentUICulture = new("en-NG");
    }
}
