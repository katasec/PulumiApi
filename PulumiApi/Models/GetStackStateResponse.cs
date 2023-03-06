using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class GetStackStateResponse : BaseResponse
{
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("deployment")]
    public Deployment? Deployment { get; set; }

    public Resource? GetResourceByName(string type, string pulumiName)
    {
        if (Deployment == null || Deployment.Resources == null) return null;
        var x = Deployment.Resources
            .Where(x => x.Type == type)
            .Where(x => x.Urn != null && x.Urn.EndsWith(pulumiName))
            .FirstOrDefault();

        return x;
    }
}
