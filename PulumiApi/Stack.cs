using System.Text.Json.Serialization;

namespace PulumiApi;

public class Stack
{
    [JsonPropertyName("orgName")]
    public string? OrgName { get; set; }

    [JsonPropertyName("projectName")]
    public string? ProjectName { get; set; }

    [JsonPropertyName("stackName")]
    public string? StackName { get; set; }

    [JsonPropertyName("lastUpdate")]
    public long LastUpdate { get; set; }

    [JsonPropertyName("resourceCount")]
    public long ResourceCount { get; set; }
}