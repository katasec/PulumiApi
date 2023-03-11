using ArkServer.Entities.Azure;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using PulumiApi.Models.PulumiState.Azure;

namespace PulumiApi.Models;

public class Deployment
{
    [JsonPropertyName("manifest")]
    public Manifest? Manifest { get; set; }

    [JsonPropertyName("secrets_providers")]
    public SecretsProviders? SecretsProviders { get; set; }

    [JsonPropertyName("resources")]
    public required List<Resource> Resources { get; set; }

    /// <summary>
    /// Returns the real name of the resource group from Azure
    /// </summary>
    /// <param name="pulumiName">Pulumi resource group name</param>
    /// <returns></returns>
    public string? GetAzureResourceGroup(string pulumiName)
    {
        if (Resources == null)  return null;

        return GetResourceNameByName(type: "azure-native:resources:ResourceGroup", pulumiName);

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

        return GetResourceNameByName(type: "azure-native:network:VirtualNetwork", pulumiName);
    }

    /// <summary>
    /// Returns the resource group name of the VNET in Azure
    /// </summary>
    /// <param name="pulumiName">Pulumi VNET name</param>
    /// <returns></returns>
    public string? GetAzureVnetRg(string pulumiName)
    {
        if (Resources == null) return null;
        var id = Resources
            .Where(x => x.Type == "azure-native:network:VirtualNetwork")
            .Where(x => x.Urn != null && x.Urn.EndsWith(pulumiName))
            .Select(x => x.Id)
            .FirstOrDefault();
        var resourceGroup = id?.Split('/')[4];
        return resourceGroup;
    }

    public VirtualNetworkState GetAzureVnetSpec(string pulumiName)
    {
        if (Resources == null) return null;

        var x = GetResourceByName(type: "azure-native:network:VirtualNetwork", pulumiName);
        var y = x.ToJson();
        var z = System.Text.Json.JsonSerializer.Deserialize<VirtualNetworkState>(y);
        return z;
    }

    public class Something
    {
        public string Urn { get; set; }
    }
    private string? GetResourceNameByName(string type, string pulumiName)
    {
        if (Resources == null) return null;
        var x = Resources
            .Where(x => x.Type == type)
            .Where(x => x.Urn != null && x.Urn.EndsWith(pulumiName))
            .Select(x => x.Outputs?["name"].ToString())
            .FirstOrDefault();

        return x;
    }

    public Resource? GetResourceByName(string type, string pulumiName)
    {
        if (Resources == null) return null;
        var x = Resources
            .Where(x => x.Type == type)
            .Where(x => x.Urn != null && x.Urn.EndsWith(pulumiName))
            .FirstOrDefault();

        return x;
    }
}
