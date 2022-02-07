using Module5HW1.Models;

namespace Module5HW1.Services.Abstractions
{
    public interface IConfigService
    {
        public void LoadConfig();
        public Config GetConfig();
    }
}
