using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace THTR.Common.DTOs.Conversation
{
    public class Conversation
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        [JsonPropertyName("stars")]
        public List<Guid> stars { get; set; }

        [JsonPropertyName("extras")]
        public List<Guid> extras { get; set; }

        [JsonPropertyName("turns")]
        public List<Guid> turns { get; set; }

        [JsonPropertyName("summary")]
        public string summary { get; set; }
    }
}
