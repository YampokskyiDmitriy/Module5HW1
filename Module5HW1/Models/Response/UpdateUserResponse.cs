using Newtonsoft.Json;

namespace Module5HW1.Models.Response
{
    public class UpdateUserResponse
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("job")]
        public string? Job { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
