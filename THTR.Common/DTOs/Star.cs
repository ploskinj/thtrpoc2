using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace THTR.Common.DTOs
{
    public class Star
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        [JsonPropertyName("handle")]
        public string handle { get; set; }

        [JsonPropertyName("first_name")]
        public string first_name { get; set; }

        [JsonPropertyName("last_name")]
        public string last_name { get; set; }

        [JsonPropertyName("backstory")]
        public string backstory { get; set; }
    }
}
