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

public class CurrentOperation
{
[JsonPropertyName("kind")]
public string? Kind { get; set; }

[JsonPropertyName("author")]
public string? Author { get; set; }

[JsonPropertyName("started")]
public DateTime? Started { get; set; }

}



public class Tags
{
[JsonPropertyName("gitHub:owner")]
public string? GitHubOwner { get; set; }

[JsonPropertyName("gitHub:repo")]
public string? GitHubRepo { get; set; }

[JsonPropertyName("pulumi:description")]
public string? PulumiDescription { get; set; }

[JsonPropertyName("pulumi:project")]
public string? PulumiProject { get; set; }

[JsonPropertyName("pulumi:runtime")]
public string? PulumiRuntime { get; set; }

[JsonPropertyName("pulumi:secrets_provider")]
public string? PulumiSecretsProvider { get; set; }

[JsonPropertyName("vcs:kind")]
public string? VcsKind { get; set; }

[JsonPropertyName("vcs:owner")]
public string? VcsOwner { get; set; }

[JsonPropertyName("vcs:repo")]
public string? VcsRepo { get; set; }
}