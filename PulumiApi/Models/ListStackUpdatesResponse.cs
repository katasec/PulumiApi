using System.Text.Json;
using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public static class Constants 
{
    public static readonly DateTime Epoch = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    public const string DateTimeFormat = "yyyy/MM/dd hh:mm:ss";
}
public class ListStackUpdatesResponse
{
    [JsonPropertyName("updates")]
    public List<Update>? Updates { get; set; }


    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions{WriteIndented = true });
    }
}

public class Update
{
    [JsonPropertyName("info")]
    public Info? Info { get; set; }

    [JsonPropertyName("updateID")]
    public string? UpdateID { get; set; }

    [JsonPropertyName("version")]
    public int? version { get; set; }

    [JsonPropertyName("latestVersion")]
    public int? latestVersion { get; set; }

    [JsonPropertyName("requestedBy")]
    public RequestedBy? RequestedBy { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions{WriteIndented = true });
    }
}

public class Info
{
    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    public DateTime EndTimeDt { 
        get{
            return Constants.Epoch.AddSeconds(Convert.ToDouble(EndTime));
        } 
    }

    public DateTime StartTimeDt { 
        get{ 
            return Constants.Epoch.AddSeconds(Convert.ToDouble(StartTime));
        } 
    }

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




public class RequestedBy
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("githubLogin")]
    public string? githubLogin { get; set; }

    [JsonPropertyName("avatarUrl")]
    public string? avatarUrl { get; set; }

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

    [JsonPropertyName("update")]
    public int? Update { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions{WriteIndented = true });
    }
}

