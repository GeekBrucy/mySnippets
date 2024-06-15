using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Interfaces;
using WebAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBrainstormSessionRepository, EFStormSessionRepository>();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
  opt.UseNpgsql("User ID=postgres;Password=postgrespw;Host=localhost;Port=5432;Database=ControllerUnitTest;");
});
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
