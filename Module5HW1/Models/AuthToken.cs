using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class AuthToken
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}
