using DemoWebAPIConfig.Data;
using DemoWebAPIConfig.Extensions;
using DemoWebAPIConfig.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(config =>
{
    config.UseNpgsql("User ID=postgres;Password=postgrespw;Host=localhost;Port=5432;Database=DotnetConfigDemo;");
});
var provider = builder.Services.BuildServiceProvider();
builder.Configuration.AddAppSettingsConfiguration(provider.GetRequiredService<MyDbContext>());

builder.Services.Configure<Smtp>(builder.Configuration.GetSection("Smtp"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
