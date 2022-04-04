using Azure.Core;
using Azure.Identity;

const string resourceSuffix = "/.default";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
DefaultAzureCredential credential = new DefaultAzureCredential();

app.MapGet("/metadata/identity/oauth2/token", async (string? resource, string? client_id) =>
{
    var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { resource + resourceSuffix }));
    return $"{{ \"access_token\": \"{token.Token}\", \"expires_on\": \"{token.ExpiresOn.ToUnixTimeSeconds()}\" }}";
});

app.Run();
