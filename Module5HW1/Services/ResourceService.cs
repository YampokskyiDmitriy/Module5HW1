using Module5HW1.Models;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;
        private readonly string? _baseUrl;
        public ResourceService(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
            _baseUrl = _configService.GetConfig().Domain;
        }

        public async Task<NotFoundResponse?> GetListResourceNotFoundAsync()
        {
            var url = @$"{_baseUrl}/api/unknown";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<NotFoundResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<SingleResourceResponse?> GetResourceAsync(int id)
        {
            var url = $"{_baseUrl}/unknown/{id}";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<SingleResourceResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<ResourceListResponse?> GetResourcesAsync()
        {
            var url = $"{_baseUrl}/unknown";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return JsonConvert.DeserializeObject<ResourceListResponse>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}