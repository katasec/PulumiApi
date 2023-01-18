using Refit;
using PulumiApi.Models;
namespace PulumiApi;

[Headers("Accept: application/vnd.pulumi+8", "Content-Type: application/json")]
public interface IPulumiApi
{
    [Get("/api/user/stacks")]
    Task<ListStacksResponse> ListStacks([Header("Authorization")] string token);

    [Get("/api/stacks/{organization}/{project}/{stack}")]
    Task<GetStackResponse> GetStack([Header("Authorization")] string token, string organization, string project, string stack);

    [Get("/api/stacks/{organization}/{project}/{stack}/export")]
    Task<GetStackStateResponse> GetStackState([Header("Authorization")] string token, string organization, string project, string stack);


    [Get("/api/stacks/{organization}/{project}/{stack}/updates?output-type=service")]
    Task<ListStackUpdatesResponse> ListStackUpdates([Header("Authorization")] string token, string organization, string project, string stack);

    [Get("/api/stacks/{organization}/{project}/{stack}/updates/latest?output-type=service")]
    Task<Update> ListStackUpdatesLatest([Header("Authorization")] string token, string organization, string project, string stack);

    [Get("/api/stacks/{organization}/{project}/{stack}/update/{updateId}")]
    Task<GetUpdateStatusResponse> GetUpdateStatus([Header("Authorization")] string token, string organization, string project, string stack, string updateId);


}
