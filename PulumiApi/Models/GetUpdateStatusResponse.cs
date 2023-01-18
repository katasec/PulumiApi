using System.Text.Json;
using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class GetUpdateStatusResponse
{
    [JsonPropertyName("status")]
    public string? Status { get; set; } 

    //[JsonPropertyName("events")]
    //public Dictionary<string, object> Events {get;set;} = new Dictionary<string, object>();
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions{WriteIndented = true });
    }
}
