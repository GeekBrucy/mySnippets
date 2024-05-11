using _02_SignalR_with_jwt.SignalR;
using IdentityServerConfig.Extensions;
using IdentityServerConfig.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = new JwtSettings
{
    ExpireSeconds = 3600,
    SecKey = "qwertyuiopasdfghjklzxcvbnm123456",
    HubUrl = "/myHub"
};
// Add services to the container.
builder.Services.Configure<JwtSettings>(opt =>
{
    opt.ExpireSeconds = jwtSettings.ExpireSeconds;
    opt.SecKey = jwtSettings.SecKey;
    opt.HubUrl = jwtSettings.HubUrl;
});
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
    .AddJwtConfig(jwtSettings);

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<MyHub>("/myHub");
app.MapControllers();

app.Run();
