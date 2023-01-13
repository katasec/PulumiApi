using Refit;

namespace PulumiApi;

public class ApiClient
{
    private readonly IPulumiApi _api;
    private readonly string _token = $"token {CredentialFile.AccessToken}";

    public ApiClient(string hostUrl= "https://api.pulumi.com")
    {
        _api = RestService.For<IPulumiApi>(hostUrl);
    }

    public async Task<GetStacksResponse> GetStacks()
    {
        return await _api.GetStacks(_token);
    }
}

