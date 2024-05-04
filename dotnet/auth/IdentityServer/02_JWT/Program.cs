using System.Reflection;
using IdentityServerConfig.Extensions;
using IdentityServerConfig.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Action<DbContextOptionsBuilder> dbContextBuilder = opt =>
{
    var connStr = builder.Configuration.GetConnectionString("postgres");

    opt.UseNpgsql(connStr, x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
};

builder.Services
    .AddDbContextConfig(dbContextBuilder)
    .AddIdentityCoreServices()
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

app.UseAuthorization();

app.MapControllers();

app.Run();
