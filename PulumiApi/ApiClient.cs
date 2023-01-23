using Refit;
using PulumiApi.Models;
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.Design;

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

    public async Task<Dictionary<string,string>?> GetStackOutput(string organization, string project, string stack)
    {
        var outputs = new Dictionary<string, string>();
        var result = await _api.GetStackState(_token, organization, project, stack);

        try
        {        
            var resource = result.Deployment?.Resources?.Where(x => x.Urn.Contains($"pulumi:pulumi:Stack::{project}-{stack}")).FirstOrDefault();
            if (resource == null || resource.Outputs == null ) return null;

            
            resource.Outputs.ToList().ForEach( x =>
            {
                if (x.Value != null) {
                    outputs.Add(x.Key, x.Value.ToString());
                }
            });
        } 
        catch (NullReferenceException) 
        { 
            return null;
        }

        return outputs;
    }

    public async Task<ListStackUpdatesResponse> ListStackUpdates(string organization, string project, string stack)
    {
        return await _api.ListStackUpdates(_token, organization, project, stack);
    }

    public async Task<Update> ListStackUpdatesLatest(string organization, string project, string stack)
    {
        return await _api.ListStackUpdatesLatest(_token, organization, project, stack);
    }

    public async Task<GetUpdateStatusResponse> GetUpdateStatus(string organization, string project, string stack, string updateId)
    {
        return await _api.GetUpdateStatus(_token, organization, project, stack, updateId);
    }

    public async Task<string> GetStackUpdatesLatestUrl(string organization, string project, string stack)
    {
        var latestUpdate = await _api.ListStackUpdatesLatest(_token, organization, project, stack);
        return $"https://app.pulumi.com/{organization}/{project}/{stack}/updates/{latestUpdate.version}";
    }

}

