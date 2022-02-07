using Newtonsoft.Json;

namespace Module5HW1.Models.Response
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}
