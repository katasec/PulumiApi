﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class ListStackUpdatesResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updates")]
    public List<Update>? Updates { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions{WriteIndented = true });
    }
}





public class Update
{
    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("startTime")]
    public long StartTime { get;set;}

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("environment")]
    public Environment? Environment { get; set; }

    [JsonPropertyName("config")]
    public Dictionary<string,Object>? Config { get; set; }

    [JsonPropertyName("result")]
    public string? Result { get; set; }

    [JsonPropertyName("endTime")]
    public long? EndTime { get; set; }

    [JsonPropertyName("version")]
    public long? Version { get; set; }

    [JsonPropertyName("resourceChanges")]
    public ResourceChanges? ResourceChanges { get; set; }
}



public class Environment
{
    [JsonPropertyName("exec.kind")]
    public string? ExecKind { get; set; }

    [JsonPropertyName("updatePlan")]
    public string? UpdatePlan { get; set; }
}

public class ResourceChanges
{
    [JsonPropertyName("create")]
    public int? Create { get; set; }

    [JsonPropertyName("delete")]
    public int? Delete { get; set; }

    [JsonPropertyName("same")]
    public int? Same { get; set; }

}
