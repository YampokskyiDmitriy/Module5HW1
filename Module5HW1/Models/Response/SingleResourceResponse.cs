﻿using Newtonsoft.Json;

namespace Module5HW1.Models.Response
{
    public class SingleResourceResponse
    {
        [JsonProperty("data")]
        public Resource? Resource { get; set; }

        [JsonProperty("support")]
        public Support? Support { get; set; }
    }
}
