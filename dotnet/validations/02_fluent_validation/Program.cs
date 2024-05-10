using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using IdentityServerConfig.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetEntryAssembly());
Action<DbContextOptionsBuilder> dbContextBuilder = opt =>
{
    var connStr = "User ID=postgres;Password=postgrespw;Host=localhost;Port=5432;Database=02_JWT;";

    opt.UseNpgsql(connStr, x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
};
builder.Services
    .AddDbContextConfig(dbContextBuilder)
    .AddIdentityCoreServices();
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
