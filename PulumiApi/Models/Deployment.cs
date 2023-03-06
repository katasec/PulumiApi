using ArkServer.Entities.Azure;
using System.Net.Http.Json;
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

    public VNetSpec GetAzureVnetSpec(string pulumiName)
    {
        if (Resources == null) return null;

        var x = GetResourceByName(type: "azure-native:network:VirtualNetwork", pulumiName);
        //var y = x.Outputs;
        //Console.WriteLine(y);
        //var z = System.Text.Json.JsonSerializer.Deserialize<Something>(x.ToJson());

        Console.WriteLine(x.Urn);
        //x.Outputs[""]
        return null;
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
