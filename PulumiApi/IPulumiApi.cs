using Refit;

namespace PulumiApi;

[Headers("Accept: application/vnd.pulumi+8", "Content-Type: application/json")]
public interface IPulumiApi
{
    [Get("/api/user/stacks")]
    Task<ListStacksResponse> ListStacks([Header("Authorization")] string token);

    [Get("/api/stacks/{organization}/{project}/{stack}")]
    Task<GetStackResponse> GetStack([Header("Authorization")] string token, string organization, string project, string stack);
}
