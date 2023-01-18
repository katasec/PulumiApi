using System.Text.Json;
using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class ListStacksResponse
{
    [JsonPropertyName("stacks")]
    public Stack[]? Stacks {get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions{WriteIndented = true });
    }
}
