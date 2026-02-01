using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace THTR.Common.DTOs.Set2D
{

    public class Set2D 
    {
        [JsonPropertyName("tileSetIds")]
        public List<int> tileSetIds { get; set; } = new List<int>();
        [JsonPropertyName("tileSets")]
        public List<TileSet> tileSets { get; set; } = new List<TileSet>();
        [JsonPropertyName("elements")]
        public List<SetElement2D> elements { get; set; } = new List<SetElement2D>();
    }
}
