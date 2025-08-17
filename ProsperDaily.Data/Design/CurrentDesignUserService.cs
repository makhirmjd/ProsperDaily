using ProsperDaily.Shared.Services;

namespace ProsperDaily.Data.Design;

public class CurrentDesignUserService : ICurrentUserService
{
    public Task<string?> GetUserId() => Task.FromResult("makhirmjd@gmail.com")!;

    public Task<string?> GetUserName() => Task.FromResult("Muhammad Abdulmalik")!;
}
