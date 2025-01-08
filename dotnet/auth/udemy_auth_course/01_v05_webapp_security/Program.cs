using _01_v05_webapp_security.Authorization.HRManager;
using _01_v05_webapp_security.Contants;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieSchemeNames.TestCookieAuth).AddCookie(CookieSchemeNames.TestCookieAuth, options =>
{
    options.Cookie.Name = CookieSchemeNames.TestCookieAuth; // Cookie.Name must match the scheme name above
    // by default, options.LoginPath is pointing to "/account/login"
    // options.LoginPath = "/whatever_path/whatever_your_login_Page_file_name";

    // by default, options.AccessDeniedPath is pointing to "/Account/AccessDenied"

    options.ExpireTimeSpan = TimeSpan.FromSeconds(20);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("MustBelongToHRDepartment", policy => policy.RequireClaim("Department", "HR"));
    options.AddPolicy("HRManagerOnly", policy => policy
        .RequireClaim("Department", "HR")
        .RequireClaim("Manager")
        .Requirements.Add(new HRManagerProbationRequirement(3)));
});

builder.Services.AddSingleton<IAuthorizationHandler, HRManagerProbationRequirementHandler>();

builder.Services.AddHttpClient(HttpClientNames.TestWebAPI, client =>
{
    client.BaseAddress = new Uri("http://localhost:5138/");
});

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

/*
app.UseAuthentication(): this middleware is responsible to call the authentication handler

it will call IAuthenticationService.AuthenticateAsync method. Then it will translate the cookies into security context
*/
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
