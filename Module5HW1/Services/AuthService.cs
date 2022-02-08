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
            var login = new Login { Email = @"peter@klaven" };
            return await _httpService.SendAsync<AuthToken>(HttpMethod.Post, url, login);
        }

        public async Task<NotFoundResponse?> PostLoginUnsuccessfulAsync()
        {
            var url = @$"{_baseUrl}/api/login";
            var login = new Login { Email = @"peter@klaven" };
            return await _httpService.SendAsync<NotFoundResponse>(HttpMethod.Post, url, login);
        }

        public async Task<AuthToken?> PostRegisterSuccessfulAsync()
        {
            var url = @$"{_baseUrl}/api/register";
            var login = new Login { Email = @"eve.holt@reqres.in", Password = "pistol" };
            return await _httpService.SendAsync<AuthToken>(HttpMethod.Post, url, login);
        }

        public async Task<ErrorResponse?> PostRegisterUnsuccessfulAsync()
        {
            var url = @$"{_baseUrl}/api/register";
            var login = new Login { Email = @"sydney@fife" };
            return await _httpService.SendAsync<ErrorResponse>(HttpMethod.Post, url, login);
        }
    }
}
