namespace ProsperDaily.Shared.Services;

public interface ICurrentUserService
{
    Task<string?> GetUserId();
    Task<string?> GetUserName();
}
