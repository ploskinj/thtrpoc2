using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using THTR.Common.DTOs.Set2D;

namespace THTR.Common.DTOs;

public class ProductionBook
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("set")]
    public Set2D Set { get; set; } 
}
