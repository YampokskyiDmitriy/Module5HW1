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
            var userRequest = new UserRequest { Name = "morpheus", Job = "leader" };
            var httpContent = new StringContent(JsonConvert.SerializeObject(userRequest), Encoding.UTF8, "application/json");
            var url = @$"{_baseUrl}/api/users";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, httpContent);
            return JsonConvert.DeserializeObject<CreateUserResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task DeleteAsync(int id)
        {
            var url = @$"{_baseUrl}/api/users/{id}";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Delete, url);
        }

        public async Task<SingleUserResponse?> GetByIdAsync(int id)
        {
            var url = @$"{_baseUrl}/api/users/{id}";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<SingleUserResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<UserListResponse?> GetUsersAsync(int page)
        {
            var url = @$"{_baseUrl}/api/users?page={page}";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<UserListResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<UpdateUserResponse?> UpdateAsyncPut()
        {
            var userRequest = new UserRequest { Name = "morpheus", Job = "zion resident" };
            var httpContent = new StringContent(JsonConvert.SerializeObject(userRequest), Encoding.UTF8, "application/json");
            var url = @$"{_baseUrl}/api/users/2";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Put, url, httpContent);
            return JsonConvert.DeserializeObject<UpdateUserResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<UpdateUserResponse?> UpdateAsyncPatch()
        {
            var userRequest = new UserRequest { Name = "morpheus", Job = "zion resident" };
            var httpContent = new StringContent(JsonConvert.SerializeObject(userRequest), Encoding.UTF8, "application/json");
            var url = @$"{_baseUrl}/api/users/2";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Patch, url, httpContent);
            return JsonConvert.DeserializeObject<UpdateUserResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<NotFoundResponse?> GetSingleUserNotFoundAsync()
        {
            var url = @$"{_baseUrl}/api/users/23";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<NotFoundResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<UserListResponse?> GetDelayedAsync()
        {
            var url = @$"{_baseUrl}/api/users?delay=3";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<UserListResponse>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
