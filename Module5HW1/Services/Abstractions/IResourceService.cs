using Module5HW1.Models;
using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstractions
{
    public interface IResourceService
    {
        public Task<ResourceListResponse?> GetResourcesAsync();
        public Task<SingleResourceResponse?> GetResourceAsync(int id);
        Task<NotFoundResponse?> GetListResourceNotFoundAsync();
    }
}