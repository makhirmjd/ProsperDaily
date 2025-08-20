namespace ProsperDaily.Services;

public class PageResolver : IPageResolver
{
    private readonly Dictionary<Type, Type> viewModelToPage = [];

    public void Map(Type viewModelType, Type pageType)
    {
        if (!viewModelToPage.ContainsKey(viewModelType))
        {
            viewModelToPage[viewModelType] = pageType;
        }
    }

    public Page ResolvePageForViewModel(Type viewModelType, IServiceProvider services)
    {
        if (viewModelToPage.TryGetValue(viewModelType, out Type? pageType))
        {
            return (Page)services.GetRequiredService(pageType);
        }
        throw new KeyNotFoundException($"No page found for ViewModel type {viewModelType.Name}");
    }
}
