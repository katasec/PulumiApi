using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class ListStacksResponse
{
    [JsonPropertyName("stacks")]
    public Stack[]? Stacks {get; set; }
}
