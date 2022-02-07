using Module5HW1.Services.Abstractions;

namespace Module5HW1
{
    public class Starter
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IAuthService _authService;

        public Starter(IUserService userService, IResourceService resourceService, IAuthService authService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _authService = authService;
        }

        public void Run()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(_userService.GetUsersAsync(2));
            tasks.Add(_userService.GetByIdAsync(2));
            tasks.Add(_userService.GetSingleUserNotFoundAsync());
            tasks.Add(_userService.CreateAsync());
            tasks.Add(_userService.UpdateAsyncPut());
            tasks.Add(_userService.UpdateAsyncPatch());
            tasks.Add(_userService.DeleteAsync(2));
            tasks.Add(_userService.GetDelayedAsync());
            tasks.Add(_resourceService.GetResourcesAsync());
            tasks.Add(_resourceService.GetResourceAsync(2));
            tasks.Add(_resourceService.GetListResourceNotFoundAsync());
            tasks.Add(_authService.PostRegisterSuccessfulAsync());
            tasks.Add(_authService.PostRegisterUnsuccessfulAsync());
            tasks.Add(_authService.PostLoginSuccessfulAsync());
            tasks.Add(_authService.PostLoginUnsuccessfulAsync());
            Task.WaitAll(tasks.ToArray());
        }
    }
}
