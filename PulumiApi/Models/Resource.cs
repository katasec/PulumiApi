using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public partial class Resource
{
    [JsonPropertyName("urn")]
    public string? Urn { get; set; }

    [JsonPropertyName("custom")]
    public bool Custom { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    //[JsonPropertyName("outputs")]
    public  Dictionary<string,object>? Outputs { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inputs")]
    public Dictionary<string, object>? Inputs { get; set; }

    //[JsonPropertyName("inputs")]
    //public Inputs? Inputs { get; set; }



    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }
}
