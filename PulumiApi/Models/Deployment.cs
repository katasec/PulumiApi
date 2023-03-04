using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace PulumiApi.Models;

public class Deployment
{
    [JsonPropertyName("manifest")]
    public Manifest? Manifest { get; set; }

    [JsonPropertyName("secrets_providers")]
    public SecretsProviders? SecretsProviders { get; set; }

    [JsonPropertyName("resources")]
    public Resource[]? Resources { get; set; }

    /// <summary>
    /// Returns the real name of the resource group from Azure
    /// </summary>
    /// <param name="pulumiName">Pulumi resource group name</param>
    /// <returns></returns>
    public string? GetAzureResourceGroup(string pulumiName)
    {
        if (Resources == null)  return null;

        return GetResourceByName(type: "azure-native:resources:ResourceGroup", pulumiName);

        //var x = Resources
        //    .Where(x => x.Type == "azure-native:resources:ResourceGroup")
        //    .Where(x => x.Urn != null &&  x.Urn.EndsWith(pulumiName))
        //    .Select(x => x.Outputs?["name"].ToString())
        //    .FirstOrDefault();

        //return x;
    }

    /// <summary>
    /// Returns the real name of the VNET in Azure
    /// </summary>
    /// <param name="pulumiName">Pulumi VNET name</param>
    /// <returns></returns>
    public string? GetAzureVnet(string pulumiName)
    {
        if (Resources == null) return null;

        return GetResourceByName(type: "azure-native:network:VirtualNetwork", pulumiName);
    }

    private string? GetResourceByName(string type, string pulumiName)
    {
        if (Resources == null) return null;
        var x = Resources
            .Where(x => x.Type == type)
            .Where(x => x.Urn != null && x.Urn.EndsWith(pulumiName))
            .Select(x => x.Outputs?["name"].ToString())
            .FirstOrDefault();

        return x;
    }
}
