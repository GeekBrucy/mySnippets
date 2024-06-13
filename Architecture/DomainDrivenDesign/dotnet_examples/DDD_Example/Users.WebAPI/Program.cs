using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Domain.Interfaces.ACL;
using Users.Domain.Interfaces.Repository;
using Users.Domain.Services;
using Users.Infrastructure.ACL;
using Users.Infrastructure.Data;
using Users.Infrastructure.Repositories;
using Users.WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<UserDbContext>(opt =>
{
    opt.UseNpgsql
    (
        "User ID=postgres;Password=postgrespw;Host=localhost;Port=5432;Database=DDD_UserManagement;",
        x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)
    );
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<UserDomainService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISmsCodeSender, MockSmsCodeSender>();
builder.Services.Configure<MvcOptions>(o =>
{
    o.Filters.Add<UnitOfWorkFilter>();
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
