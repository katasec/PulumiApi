# Overview

A dotnet client for the [Pulumi Service Rest API](https://www.pulumi.com/docs/reference/service-rest-api/). Adding some methods as needed. Please check [here](./PulumiApi.Test/UnitTest1.cs) or 
[here](./PulumiApi/IPulumiApi.cs) to see what's been implemented.

The client authenticates against your pulumi account using the credential file in `~/.pulumi/credentials.json`. 

## Example 1: List All Stacks

```csharp
var client = new PulumiApi.ApiClient();
var result = await client.ListStacks();

Console.WriteLine("Stacks in your account:");
result.Stacks?.ToList().ForEach(x =>
{
    Console.WriteLine($"- {x.OrgName}/{x.ProjectName}/{x.StackName}");
});
```