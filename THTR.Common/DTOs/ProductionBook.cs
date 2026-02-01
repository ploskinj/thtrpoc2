using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using THTR.Common.DTOs.Set2D;

namespace THTR.Common.DTOs;

public class ProductionBook
{
    [JsonPropertyName("id")]
    public int id { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; } = string.Empty;

    [JsonPropertyName("set")]
    public Set2D.Set2D set { get; set; }
}
