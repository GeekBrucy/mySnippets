using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

var defaultCookieScheme = "MyCookieScheme";
var myPolicy = "MyPolicy";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<MyAuthService>();
builder.Services.AddAuthentication(defaultCookieScheme).AddCookie(defaultCookieScheme);
builder.Services.AddAuthorization(builder =>
{
    builder.AddPolicy(myPolicy, policyConfig =>
    {
        policyConfig.RequireClaim("special", "allow");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapGet("other", (HttpContext ctx) =>
{
    var cookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));

    return cookie ?? "empty";
});

app.MapGet("otherCookie", (HttpContext ctx) =>
{
    bool isAuth = ctx.User.Identities.Any(c => c.AuthenticationType == defaultCookieScheme);

    if (isAuth)
    {
        return "Authed";
    }
    else
    {
        return "NOT Authed";
    }
});
app.MapGet("special", (HttpContext ctx) =>
{
    bool isAuth = ctx.User.Identities.Any(c => c.AuthenticationType == defaultCookieScheme);

    if (isAuth)
    {
        return "Authed";
    }
    else
    {
        return "NOT Authed";
    }
}).RequireAuthorization(myPolicy);

app.MapGet("login", (MyAuthService auth) =>
{
    auth.Signin();
    return "ok";
});

app.MapGet("loginCookie", async (HttpContext ctx) =>
{
    // claim                : user info
    // claimIdentity        : identity
    // claimsPrincipal      : give the identity to a user
    List<Claim> claims = new List<Claim>
    {
        new Claim("name", "Test"),
        new Claim("special", "allow")
    };
    var identity = new ClaimsIdentity(claims, defaultCookieScheme);
    await ctx.SignInAsync(defaultCookieScheme, new ClaimsPrincipal(identity));
    return "ok";
});

app.MapControllers();

app.Run();


public class MyAuthService
{
    private readonly IHttpContextAccessor _ctx;

    public MyAuthService(IHttpContextAccessor ctx)
    {
        _ctx = ctx;
    }

    public void Signin()
    {
        _ctx.HttpContext.Response.Headers["set-cookie"] = "auth=name:test";
    }
}