using Module5HW1.Models;
using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstractions
{
    public interface IUserService
    {
        public Task<UserListResponse?> GetUsersAsync(int page);
        public Task<SingleUserResponse?> GetByIdAsync(int id);
        public Task<CreateUserResponse?> CreateAsync();
        public Task<UpdateUserResponse?> UpdateAsyncPut();
        public Task<UpdateUserResponse?> UpdateAsyncPatch();
        public Task<NotFoundResponse?> GetSingleUserNotFoundAsync();
        public Task DeleteAsync(int id);
        public Task<UserListResponse?> GetDelayedAsync();
    }
}