using System.Text.Json.Serialization;

namespace PulumiApi;

public class GetStacksResponse
{
    [JsonPropertyName("stacks")]
    public Stack[]? Stacks {get; set; }
}
