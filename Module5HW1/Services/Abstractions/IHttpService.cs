namespace Module5HW1.Services.Abstractions
{
    public interface IHttpService
    {
        public Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string url, HttpContent? content = null);
    }
}
