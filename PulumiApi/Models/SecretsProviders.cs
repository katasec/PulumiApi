using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public partial class SecretsProviders
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("state")]
    public State? State { get; set; }
}
