using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class CurrentOperation
{
[JsonPropertyName("kind")]
public string? Kind { get; set; }

[JsonPropertyName("author")]
public string? Author { get; set; }

[JsonPropertyName("started")]
public DateTime? Started { get; set; }

}
