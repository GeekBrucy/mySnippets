using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
    options.ResponseType = builder.Configuration["Authentication:Cognito:ResponseType"] ?? string.Empty;
    options.MetadataAddress = builder.Configuration["Authentication:Cognito:MetadataAddress"] ?? string.Empty;
    options.ClientId = builder.Configuration["Authentication:Cognito:ClientId"] ?? string.Empty;
    options.ClientSecret = builder.Configuration["Authentication:Cognito:Secret"] ?? string.Empty;
    options.Events = new OpenIdConnectEvents()
    {
        OnRedirectToIdentityProviderForSignOut = OnRedirectToIdentityProviderForSignOut
    };
});

Task OnRedirectToIdentityProviderForSignOut(RedirectContext context)
{
    context.ProtocolMessage.Scope = "openid";
    context.ProtocolMessage.ResponseType = "code";

    var cognitoDomain = builder.Configuration["Authentication:Cognito:CognitoDomain"];

    var clientId = builder.Configuration["Authentication:Cognito:ClientId"];

    var logoutUrl = $"{context.Request.Scheme}://{context.Request.Host}{builder.Configuration["Authentication:Cognito:AppSignOutUrl"]}";

    context.ProtocolMessage.IssuerAddress = $"{cognitoDomain}/logout?client_id={clientId}&logout_uri={logoutUrl}&redirect_uri={logoutUrl}";

    // delete cookies
    context.Properties.Items.Remove(CookieAuthenticationDefaults.AuthenticationScheme);
    // close openid session
    context.Properties.Items.Remove(OpenIdConnectDefaults.AuthenticationScheme);

    return Task.CompletedTask;
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
