using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public partial class Manifest
{
    [JsonPropertyName("time")]
    public DateTimeOffset Time { get; set; }

    [JsonPropertyName("magic")]
    public string? Magic { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
