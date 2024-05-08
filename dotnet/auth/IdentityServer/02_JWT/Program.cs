using System.Reflection;
using _02_JWT.Filters;
using IdentityServerConfig.Extensions;
using IdentityServerConfig.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var scheme = new OpenApiSecurityScheme()
    {
        Description = "Authorization header. \r\nExample: 'Bearer 12345abcdef'",
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Authorization" },
        Scheme = "oauth2",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    };
    c.AddSecurityDefinition("Authorization", scheme);
    var requirement = new OpenApiSecurityRequirement();
    requirement[scheme] = new List<string>();
    c.AddSecurityRequirement(requirement);
});
Action<DbContextOptionsBuilder> dbContextBuilder = opt =>
{
    var connStr = builder.Configuration.GetConnectionString("postgres");

    opt.UseNpgsql(connStr, x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
};
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<JwtVersionCheckFilter>();
});
builder.Services
    .AddDbContextConfig(dbContextBuilder)
    .AddIdentityCoreServices()
    .AddJwtConfig(builder.Configuration.GetSection("JWT"))
    ;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    try
    {
        await DbInitializer.InitDbAndSeedUser(app.Services);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
