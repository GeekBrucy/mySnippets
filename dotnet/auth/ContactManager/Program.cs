using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;
using Microsoft.AspNetCore.Authorization;
using ContactManager.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

// fallback policy applies to razor pages, controllers or action methods that do now have applied authorization attribute, like [AllowAnonymous] etc.
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

// Authorization handlers
builder.Services
    .AddScoped<IAuthorizationHandler, ContactIsOwnerAuthorizationHandler>();

/*
ContactAdministratorsAuthorizationHandler is singleton,
because it doesn't use EF
*/
builder.Services
    .AddSingleton<IAuthorizationHandler, ContactAdministratorsAuthorizationHandler>();
/*
ContactAdministratorsAuthorizationHandler is singleton,
because it doesn't use EF
*/
builder.Services
    .AddSingleton<IAuthorizationHandler, ContactManagerAuthorizationHandler>();
/*
An alternative way for MVC controllers and Razor Pages to require all users be authenticated is adding an authorization filter:
*/
/*
builder.Services.AddControllers(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
*/

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();

    context.Database.Migrate();

    var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");

    await SeedData.Initialize(services, testUserPw);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
