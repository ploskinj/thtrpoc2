using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace THTR.Common.DTOs.Set2D
{
    public class SetElement2D
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("mapX")]
        public int MapX { get; set; }

        [JsonPropertyName("mapY")]
        public int MapY { get; set; }

        [JsonPropertyName("tileSetId")]
        public int TileSetId { get; set; }

        [JsonPropertyName("tileId")]
        public int TileId { get; set; }
    }
}
