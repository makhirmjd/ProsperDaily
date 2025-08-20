
namespace ProsperDaily.Services;

public interface IPageResolver
{
    Page ResolvePageForViewModel(Type viewModelType, IServiceProvider services);
}