using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace THTR.Common.DTOs.Set2D
{
    public class Avatar
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        [JsonPropertyName("body_id")]
        public int body_id { get; set; }

        [JsonPropertyName("skin_tone_id")]
        public int skin_tone_id { get; set; }

        [JsonPropertyName("hair_style_id")]
        public int hair_style_id { get; set; }

        [JsonPropertyName("hair_color_id")]
        public int hair_color_id { get; set; }
    }
}
