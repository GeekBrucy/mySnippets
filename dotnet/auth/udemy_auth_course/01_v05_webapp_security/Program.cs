using _01_v05_webapp_security.Contants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieSchemeNames.TestCookieAuth).AddCookie(CookieSchemeNames.TestCookieAuth, options =>
{
    options.Cookie.Name = CookieSchemeNames.TestCookieAuth; // Cookie.Name must match the scheme name above
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
