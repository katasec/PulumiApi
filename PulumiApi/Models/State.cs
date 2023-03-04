using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public partial class State
{
    [JsonPropertyName("url")]
    public Uri? Url { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("project")]
    public string? Project { get; set; }

    [JsonPropertyName("stack")]
    public string? Stack { get; set; }
}
