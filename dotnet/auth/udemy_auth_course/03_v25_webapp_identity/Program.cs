using System.IdentityModel.Tokens.Jwt;
using _03_v25_webapp_identity.Data;
using _03_v25_webapp_identity.Data.Account;
using _03_v25_webapp_identity.Services;
using _03_v25_webapp_identity.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var connStr = builder.Configuration.GetConnectionString("postgres");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connStr);
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    // you can configure the password requirement, but for demo purpose, just 8 character password will do
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SMTPSettings"));

builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = builder.Configuration["FaceBookAuth:AppId"] ?? string.Empty;
    options.AppSecret = builder.Configuration["FaceBookAuth:Secret"] ?? string.Empty;
})
.AddCookie()
.AddOpenIdConnect("Cognito", options =>
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
app.MapControllers();
app.Run();
