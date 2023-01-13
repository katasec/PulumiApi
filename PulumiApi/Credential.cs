using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PulumiApi;

public class Credential
{
    public required string Current { get; set; }
    public required  Dictionary<string, AccountInfo> Accounts { get; set; }

    public required Dictionary<string,string> AccessTokens { get; set; }

}

public static class CredentialFile
{
    private static readonly string HomeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    private static readonly string JsonFile = Path.Join(HomeDir, ".pulumi", "credentials.json");
    private static readonly JsonSerializerOptions? Options = new() { PropertyNameCaseInsensitive = true };
    public static Credential Cred { get;  }

    public static Dictionary<string, AccountInfo> Accounts { get; set; }

    /// <summary>
    /// Pulumi 
    /// </summary>
    public static string AccessToken { get; set; }


    public static string Current { get; set; }
    /// <summary>
    /// CredentialFile reads the pulumi credential file to provide Pulumi Account and Credential Tokens.
    /// </summary>
    /// <exception cref="ApplicationException"></exception>
    static CredentialFile()
    {
        string pulumiCred;
        try
        {
            pulumiCred = File.ReadAllText(JsonFile);
        }
        catch (Exception)
        {
            Console.WriteLine("Could not read pulumi credential file:" + JsonFile);
            //Console.WriteLine(e.Message);
            throw;
        }

        if (string.IsNullOrEmpty(pulumiCred))
        {
            throw new ApplicationException("Pulumi Credential file was empty. Please run pulumi login");
        }


        try
        {
            var cred = JsonSerializer.Deserialize<Credential>(pulumiCred, Options);
            Cred = cred ?? throw new ApplicationException("Credential was null");
        }
        catch (Exception)
        {
            var message = $"Missing credentials in {JsonFile}. Please run pulumi login.\n";
            throw new ApplicationException(message);
        }


        
        Accounts = Cred.Accounts;
        Current = Cred.Current;
        AccessToken = Cred.AccessTokens["https://api.pulumi.com"];
    }
}

public class AccountInfo
{
    public string? AccessToken { get; set; }
    public string? UserName { get; set; }
    public List<string>? Organizations { get; set; }

    public DateTime LastValidatedAt { get; set; }
}




