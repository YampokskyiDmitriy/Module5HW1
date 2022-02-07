using Microsoft.Extensions.DependencyInjection;
using Module5HW1.Services;
using Module5HW1.Services.Abstractions;

namespace Module5HW1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ioc = new ServiceCollection()
               .AddSingleton<IConfigService, ConfigService>()
               .AddSingleton<IHttpService, HttpService>()
               .AddTransient<IUserService, UserService>()
               .AddTransient<IAuthService, AuthService>()
               .AddTransient<IResourceService, ResourceService>()
               .AddTransient<Starter>()
               .BuildServiceProvider();
            var starter = ioc.GetService<Starter>();
            starter?.Run();
            Console.Read();
        }
    }
}