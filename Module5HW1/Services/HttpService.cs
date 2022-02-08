using System.Text;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T?> SendAsync<T>(HttpMethod httpMethod, string url, object? content = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            if (content is not null)
            {
                var httpContent = new StringContent(
                JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");
                request.Content = httpContent;
            }

            var response = await _httpClient.SendAsync(request);
            var jsonContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}