using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace THTR.Common.DTOs.ClientUIDTOs
{
    public class TileSet
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("spriteSheetPath")]
        public string SpriteSheetPath { get; set; }

        [JsonPropertyName("tiles")]
        public List<Tile> Tiles { get; set; }
    }

    public class Tile
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ssx")]
        public int Ssx { get; set; }

        [JsonPropertyName("ssy")]
        public int Ssy { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("collidable")]
        public bool Collidable { get; set; }

        [JsonPropertyName("visible")]
        public bool Visible { get; set; }
    }
}
