using ActionFilterUseCase_AutoTransaction.Data;
using ActionFilterUseCase_AutoTransaction.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    opt.UseNpgsql("User ID=postgres;Password=postgrespw;Host=localhost;Port=5432;Database=DotnetConfigDemo;");
});
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<TransactionScopeFilter>();
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
