using System.Text.Json.Serialization;

namespace PulumiApi;

public class ListStacksResponse
{
    [JsonPropertyName("stacks")]
    public Stack[]? Stacks {get; set; }
}
