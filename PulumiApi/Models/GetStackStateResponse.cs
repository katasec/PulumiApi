using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PulumiApi.Models;

public class GetStackStateResponse
{
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("deployment")]
    public Deployment? Deployment { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}

public class Deployment
{
    [JsonPropertyName("manifest")]
    public Manifest? Manifest { get; set; }

    [JsonPropertyName("secrets_providers")]
    public SecretsProviders? SecretsProviders { get; set; }

    [JsonPropertyName("resources")]
    public Resource[]? Resources { get; set; }
}

public partial class Manifest
{
    [JsonPropertyName("time")]
    public DateTimeOffset Time { get; set; }

    [JsonPropertyName("magic")]
    public string? Magic { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}

public partial class Resource
{
    [JsonPropertyName("urn")]
    public string? Urn { get; set; }

    [JsonPropertyName("custom")]
    public bool Custom { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    //[JsonPropertyName("outputs")]
    public  Dictionary<string,object>? Outputs { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inputs")]
    public Dictionary<string, object>? Inputs { get; set; }

    //[JsonPropertyName("inputs")]
    //public Inputs? Inputs { get; set; }



    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

}

public partial class SecretsProviders
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("state")]
    public State? State { get; set; }
}

public partial class State
{
    [JsonPropertyName("url")]
    public Uri? Url { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("project")]
    public string? Project { get; set; }

    [JsonPropertyName("stack")]
    public string? Stack { get; set; }
}


public class Inputs
{
    [JsonPropertyName("__createBeforeDelete")]
    public bool CreateBeforeDelete { get; set; }

    public Dictionary<string,string>? Stuff { get; set; }
}