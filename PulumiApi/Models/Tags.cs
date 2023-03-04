using System.Text.Json.Serialization;

namespace PulumiApi.Models;

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