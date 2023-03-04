using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class Inputs
{
    [JsonPropertyName("__createBeforeDelete")]
    public bool CreateBeforeDelete { get; set; }

    public Dictionary<string,string>? Stuff { get; set; }
}