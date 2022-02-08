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
            return await _httpService.SendAsync<NotFoundResponse>(HttpMethod.Get, url);
        }

        public async Task<SingleResourceResponse?> GetResourceAsync(int id)
        {
            var url = @$"{_baseUrl}/api/unknown/{id}";
            return await _httpService.SendAsync<SingleResourceResponse>(HttpMethod.Get, url);
        }

        public async Task<ResourceListResponse?> GetResourcesAsync()
        {
            var url = @$"{_baseUrl}/api/unknown";
            return await _httpService.SendAsync<ResourceListResponse>(HttpMethod.Get, url);
        }
    }
}