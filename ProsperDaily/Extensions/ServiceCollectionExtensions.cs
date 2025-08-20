using ProsperDaily.Services;

namespace ProsperDaily.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPage<TPage, TViewModel>(this IServiceCollection services)
        where TPage : Page
        where TViewModel : class
    {
        services.AddTransient<TViewModel>();

        services.AddTransient(provier =>
        {
            TViewModel viewModel = provier.GetRequiredService<TViewModel>();
            TPage page = ActivatorUtilities.CreateInstance<TPage>(provier);
            page.BindingContext = viewModel;
            return page;
        });

        services.AddSingleton(provider =>
        {
            IPageResolver baseResolver = provider.GetService<IPageResolver>() ?? new PageResolver();
            ((PageResolver)baseResolver).Map(typeof(TViewModel), typeof(TPage));
            return baseResolver;
        });

        return services;
    }
}
