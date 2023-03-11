using Pulumi.AzureNative.Databricks.Inputs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PulumiApi.Models.PulumiState.Azure;

public class VirtualNetworkState
{
    [JsonPropertyName("type")]
    public string?  Type { get; set; }

    [JsonPropertyName("Outputs")]
    public required VirtualNetwork Outputs { get; set; }
    
}


public class VirtualNetwork
{
    [JsonPropertyName("addressSpace")]
    public required AddressSpace AddressSpace { get; set; }

    [JsonPropertyName("subnets")]
    public required List<Subnet> Subnets { get; set; }
}
public class AddressSpace
{
    [JsonPropertyName("addressPrefixes")]
    public required List<string> AddressPrefixes { get; set; }
}

public class Subnet
{
    [JsonPropertyName("addressPrefix")]
    public required string AddressPrefix { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}