using Refit;

namespace PulumiApi;

[Headers("Accept: application/vnd.pulumi+8", "Content-Type: application/json")]
public interface IPulumiApi
{
    [Get("/api/user/stacks")]
    Task<GetStacksResponse> GetStacks([Header("Authorization")] string token);
}
