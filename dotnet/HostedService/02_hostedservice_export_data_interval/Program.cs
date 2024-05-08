using _02_hostedservice_export_data_interval.Data;
using _02_hostedservice_export_data_interval.HostedServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<ScheduledServices>();
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    opt.UseNpgsql("User ID=postgres;Password=postgrespw;Host=localhost;Port=5432;Database=02_JWT;");
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
