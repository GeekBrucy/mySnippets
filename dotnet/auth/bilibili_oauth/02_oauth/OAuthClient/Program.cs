using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.WebUtilities;

var builder = WebApplication.CreateBuilder(args);

var cookieScheme = "cookie-client";
var oauthScheme = "custom-oauth";
var clientId = "explore";
var clientSecret = "client-secret";
var authEndpoint = "https://localhost:5005/oauth/authorize";
var tokenEndpoint = "https://localhost:5005/oauth/token";
var oauthCallback = "/auth/callback";

builder.Services.AddAuthentication(cookieScheme)
    .AddCookie(cookieScheme)
    .AddOAuth(oauthScheme, o =>
    {
        o.SignInScheme = cookieScheme;
        o.ClientId = clientId;
        o.ClientSecret = clientSecret;
        o.AuthorizationEndpoint = authEndpoint;
        o.TokenEndpoint = tokenEndpoint;
        o.CallbackPath = oauthCallback;
        // UsePkce: 请求code时, 多添加两个参数: code-challenge (sha256 + base64), code-challenge-method
        // 请求token时, 会添加code-verifier (string + base64)
        o.UsePkce = true;
        o.ClaimActions.MapJsonKey("sub", "sub");
        o.ClaimActions.MapJsonKey("custom", "custom");
        o.Events.OnCreatingTicket = ctx =>
        {
            var payload = ctx.AccessToken?.Split('.')[1];
            if (!string.IsNullOrEmpty(payload))
            {
                var json = Base64UrlTextEncoder.Decode(payload);
                var load = JsonDocument.Parse(json);
                ctx.RunClaimActions(load.RootElement);
            }
            return Task.CompletedTask;
        };
    });

var app = builder.Build();

app.UseAuthentication();

// app.UseAuthorization();

app.MapGet("/", (HttpContext ctx) =>
{
    return ctx.User.Claims.Select(x => new { x.Type, x.Value }).ToList();
});

app.MapGet("/login", (HttpContext ctx) =>
{
    return Results.Challenge
    (
        new AuthenticationProperties
        {
            RedirectUri = "https://localhost:5004"
        },
        authenticationSchemes: new List<string> { oauthScheme }
    );
});

app.Run();
