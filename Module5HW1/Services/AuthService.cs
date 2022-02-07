using System.Text;
using Module5HW1.Models;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;
        private readonly string? _baseUrl;
        public AuthService(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
            _baseUrl = _configService.GetConfig().Domain;
        }

        public async Task<AuthToken?> PostLoginSuccessfulAsync()
        {
            var url = @$"{_baseUrl}/api/login";
            var login = new Login { Email = @"eve.holt@reqres.in", Password = "cityslicka" };
            var httpContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, httpContent);
            return JsonConvert.DeserializeObject<AuthToken>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<NotFoundResponse?> PostLoginUnsuccessfulAsync()
        {
            var url = @$"{_baseUrl}/api/login";
            var login = new Login { Email = @"peter@klaven" };
            var httpContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, httpContent);
            return JsonConvert.DeserializeObject<NotFoundResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<AuthToken?> PostRegisterSuccessfulAsync()
        {
            var url = @$"{_baseUrl}/api/register";
            var login = new Login { Email = @"eve.holt@reqres.in", Password = "cityslicka" };
            var httpContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, httpContent);
            return JsonConvert.DeserializeObject<AuthToken>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<ErrorResponse?> PostRegisterUnsuccessfulAsync()
        {
            var url = @$"{_baseUrl}/api/register";
            var login = new Login { Email = @"peter@klaven" };
            var httpContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, httpContent);
            return JsonConvert.DeserializeObject<ErrorResponse>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
