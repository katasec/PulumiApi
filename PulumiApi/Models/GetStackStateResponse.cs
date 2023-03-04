using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PulumiApi.Models;

public class GetStackStateResponse : BaseResponse
{
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("deployment")]
    public Deployment? Deployment { get; set; }
}
