using System.Text.Json;
using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class GetStackResponse : BaseResponse
{
    [JsonPropertyName("orgName")]
    public string? OrgName { get; set; }

    [JsonPropertyName("projectName")]
    public string? ProjectName { get; set; }

    [JsonPropertyName("stackName")]
    public string? StackName { get; set; }

    [JsonPropertyName("currentOperation")]
    public CurrentOperation? CurrentOperation {get; set; }

    [JsonPropertyName("activeUpdate")]
    public string? ActiveUpdate {get; set; }

    [JsonPropertyName("tags")]
    public Tags? Tags { get; set; }

    //[JsonPropertyName("tags")]
    //public Dictionary<string,string> Tags { get; set;}

    [JsonPropertyName("version")]
    public int? Version { get; set; }

}
