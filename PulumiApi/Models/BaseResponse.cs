using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PulumiApi.Models;

public class BaseResponse
{
}


public static class BaseResponseExtensions
{
    public static string? ToJson<T>(this T self) where T: BaseResponse?
    {
        return JsonSerializer.Serialize(self, new JsonSerializerOptions { WriteIndented = true });
    }

}
