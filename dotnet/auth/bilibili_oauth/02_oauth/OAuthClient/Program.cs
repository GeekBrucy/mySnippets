using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using OAuthClient;
using OAuthClient.Constants;
// using Microsoft.AspNetCore.WebUtilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TokenManage>()
    .AddTransient<Refresh>()
    .AddHttpClient<PollyRefreshToken>()
    .AddPolicyHandler(PollyRefreshToken.HandleUnAuthorized);

builder.Services.AddAuthentication(AuthConstants.cookieScheme)
    .AddCookie(AuthConstants.cookieScheme)
    .AddOAuth(AuthConstants.oauthScheme, o =>
    {
        o.SignInScheme = AuthConstants.cookieScheme;
        o.ClientId = AuthConstants.clientId;
        o.ClientSecret = AuthConstants.clientSecret;
        o.AuthorizationEndpoint = AuthConstants.authEndpoint;
        o.TokenEndpoint = AuthConstants.tokenEndpoint;
        o.CallbackPath = AuthConstants.oauthCallback;
        o.UserInformationEndpoint = AuthConstants.userInfoEndpoint;
        // UsePkce: 请求code时, 多添加两个参数: code-challenge (sha256 + base64), code-challenge-method
        // 请求token时, 会添加code-verifier (string + base64)
        o.UsePkce = true;
        o.ClaimActions.MapJsonKey("sub", "sub");
        o.ClaimActions.MapJsonKey("custom", "custom");
        o.Events.OnCreatingTicket = async ctx =>
        {
            // var payload = ctx.AccessToken?.Split('.')[1];
            // if (!string.IsNullOrEmpty(payload))
            // {
            //     var json = Base64UrlTextEncoder.Decode(payload);
            //     var load = JsonDocument.Parse(json);
            //     ctx.RunClaimActions(load.RootElement);
            // }
            // return Task.CompletedTask;
            var request = new HttpRequestMessage(HttpMethod.Get, ctx.Options.UserInformationEndpoint);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ctx.AccessToken);

            var db = ctx.HttpContext.RequestServices.GetRequiredService<TokenManage>();

            var result = await ctx.Backchannel.SendAsync(request);

            var content = await result.Content.ReadAsStringAsync();

            var userJson = JsonDocument.Parse(content).RootElement;

            var name = userJson.GetProperty("sub").ToString();

            db.Save
            (
                name,
                new TokenManage.TokenInfo
                (
                    ctx.AccessToken,
                    ctx.RefreshToken,
                    Convert.ToDateTime(ctx.TokenResponse.ExpiresIn)
                )
            );
            ctx.Identity.AddClaim(new Claim("name", name));
        };
    });

var app = builder.Build();

app.UseAuthentication();

// app.UseAuthorization();

app.MapGet("/", (HttpContext ctx) =>
{
    return ctx.User.Claims.Select(x => new { x.Type, x.Value }).ToList();
});
app.MapGet("/info", async (PollyRefreshToken client, HttpContext ctx) =>
{
    var name = ctx.User.FindFirstValue("name");

    return await client.GetInfo(name);
});

app.MapGet("/login", (HttpContext ctx) =>
{
    return Results.Challenge
    (
        new AuthenticationProperties
        {
            RedirectUri = "https://localhost:5004"
        },
        authenticationSchemes: new List<string> { AuthConstants.oauthScheme }
    );
});

app.Run();
