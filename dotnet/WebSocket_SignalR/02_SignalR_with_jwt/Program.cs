using _02_SignalR_with_jwt.SignalR;
using IdentityServerConfig.Extensions;
using IdentityServerConfig.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services
    .AddDbContextConfig(opt =>
    {
        opt.UseNpgsql("User ID=postgres;Password=postgrespw;Host=localhost;Port=5432;Database=02_JWT;");
    })
    .AddIdentityCoreServices()
    .AddJwtConfig(new JwtSettings { ExpireSeconds = 3600, SecKey = "qwertyuiopasdfghjklzxcvbnm123456", HubUrl = "/myHub" });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<MyHub>("/myHub");
app.MapControllers();

app.Run();
