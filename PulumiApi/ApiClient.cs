using Refit;
using PulumiApi.Models;
namespace PulumiApi;

public class ApiClient
{
    private readonly IPulumiApi _api;
    private readonly string _token = $"token {CredentialFile.AccessToken}";

    public ApiClient(string hostUrl= "https://api.pulumi.com")
    {
        _api = RestService.For<IPulumiApi>(hostUrl);
    }

    public async Task<ListStacksResponse> ListStacks()
    {
        return await _api.ListStacks(_token);
    }

    public async Task<GetStackResponse> GetStack(string organization, string project, string stack)
    {
        return await _api.GetStack(_token, organization, project, stack);
    }

    public async Task<GetStackStateResponse> GetStackState(string organization, string project, string stack)
    {
        return await _api.GetStackState(_token, organization, project, stack);
    }
}

