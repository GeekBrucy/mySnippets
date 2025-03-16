using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var defaultCookieScheme = "MyCookieScheme";
var bearerAuth = "MyBearer";
var key = RSA.Create();
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

builder.Services.AddAuthentication(bearerAuth).AddJwtBearer(bearerAuth, opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidAudience = "jwt-explore",
        IssuerSigningKey = new RsaSecurityKey(key)
    };
    opt.Events = new JwtBearerEvents
    {
        OnMessageReceived = (ctx) =>
        {
            if (ctx.Request.Query.ContainsKey("token"))
            {
                ctx.Token = ctx.Request.Query["token"];
            }
            return Task.CompletedTask;
        }
    };
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

app.MapGet("otherJWT", (string token, HttpContext ctx) =>
{
    bool isAuthed = ctx.User.Claims.Any(x => x.Issuer == "Test");

    return isAuthed;
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

app.MapGet("jwt", (HttpContext ctx) =>
{
    var secret = new RsaSecurityKey(key);
    var jwt = new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor()
    {
        Subject = new ClaimsIdentity
        (
            new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Iss, "Test"),
                new Claim(JwtRegisteredClaimNames.Aud, "jwt-explore"),
                new Claim("sub", "exploring")
            },
            bearerAuth
        ),
        SigningCredentials = new SigningCredentials(secret, SecurityAlgorithms.RsaSha256)
    });

    return jwt;
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