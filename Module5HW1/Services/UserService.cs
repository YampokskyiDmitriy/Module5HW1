using System.Text;
using Module5HW1.Models;
using Module5HW1.Models.Requests;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;
        private readonly string? _baseUrl;
        public UserService(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
            _baseUrl = _configService.GetConfig().Domain;
        }

        public async Task<CreateUserResponse?> CreateAsync()
        {
            var url = @$"{_baseUrl}/api/users";
            var userRequest = new UserRequest { Name = "morpheus", Job = "leader" };
            return await _httpService.SendAsync<CreateUserResponse>(HttpMethod.Post, url, userRequest);
        }

        public async Task<NotFoundResponse?> DeleteAsync(int id)
        {
            var url = @$"{_baseUrl}/api/users/{id}";
            return await _httpService.SendAsync<NotFoundResponse>(HttpMethod.Delete, url);
        }

        public async Task<SingleUserResponse?> GetByIdAsync(int id)
        {
            var url = @$"{_baseUrl}/api/users/{id}";
            return await _httpService.SendAsync<SingleUserResponse>(HttpMethod.Get, url);
        }

        public async Task<UserListResponse?> GetDelayedAsync()
        {
            var url = @$"{_baseUrl}/api/users?delay=3";
            return await _httpService.SendAsync<UserListResponse>(HttpMethod.Get, url);
        }

        public async Task<NotFoundResponse?> GetSingleUserNotFoundAsync()
        {
            var url = @$"{_baseUrl}/api/users/23";
            return await _httpService.SendAsync<NotFoundResponse>(HttpMethod.Get, url);
        }

        public async Task<UserListResponse?> GetUsersAsync(int page)
        {
            var url = @$"{_baseUrl}/api/users?page={page}";
            return await _httpService.SendAsync<UserListResponse>(HttpMethod.Get, url);
        }

        public async Task<UpdateUserResponse?> UpdateAsyncPatch()
        {
            var url = @$"{_baseUrl}/api/users/2";
            var userRequest = new UserRequest { Name = "morpheus", Job = "zion resident" };
            return await _httpService.SendAsync<UpdateUserResponse>(HttpMethod.Patch, url, userRequest);
        }

        public async Task<UpdateUserResponse?> UpdateAsyncPut()
        {
            var url = @$"{_baseUrl}/api/users/2";
            var userRequest = new UserRequest { Name = "morpheus", Job = "zion resident" };
            return await _httpService.SendAsync<UpdateUserResponse>(HttpMethod.Put, url, userRequest);
        }
    }
}
