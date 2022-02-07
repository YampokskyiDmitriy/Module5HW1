using Module5HW1.Models;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class ConfigService : IConfigService
    {
        private Config _config;
        public ConfigService()
        {
            LoadConfig();
        }

        public Config GetConfig()
        {
            return _config;
        }

        public void LoadConfig()
        {
            var config = File.ReadAllText("config.json");
            _config = JsonConvert.DeserializeObject<Config>(config);
        }
    }
}
