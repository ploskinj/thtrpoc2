using System;
using System.Text.Json.Serialization;

namespace THTR.Common.DTOs.ConversationDTOs;

public class Character
{
    [JsonPropertyName("id")]
    public Guid id { get; set; }

    [JsonPropertyName("first_name")]
    public string? first_name { get; set; }

    [JsonPropertyName("last_name")]
    public string? last_name { get; set; }

    [JsonPropertyName("backstory")]
    public string? backstory { get; set; }

    [JsonPropertyName("age")]
    public int? age { get; set; }

    [JsonPropertyName("location")]
    public string? location { get; set; }

    [JsonPropertyName("identity")]
    public string? identity { get; set; }

    [JsonPropertyName("education")]
    public string? education { get; set; }

    [JsonPropertyName("occupation")]
    public string? occupation { get; set; }

    [JsonPropertyName("family")]
    public string? family { get; set; }

    [JsonPropertyName("personality")]
    public string? personality { get; set; }

    [JsonPropertyName("worldview")]
    public string? worldview { get; set; }
}
