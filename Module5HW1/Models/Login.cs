using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class Login
    {
        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}