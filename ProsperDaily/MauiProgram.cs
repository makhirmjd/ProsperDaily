using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using ProsperDaily.Data;
using ProsperDaily.Services;
using ProsperDaily.Shared.Services;

namespace ProsperDaily;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        ConfigureDatabaseService(builder.Services);
        builder
            .UseMauiApp<App>()
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

        ConfigureServices(builder.Services);

        return builder.Build();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
    }

    private static void ConfigureDatabaseService(IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite($"Filename={DatabasePath}"));
        using AsyncServiceScope scope = services.BuildServiceProvider().CreateAsyncScope();
        ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}
