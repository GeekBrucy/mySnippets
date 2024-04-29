using System.Reflection;
using EntityLib.Data;
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
/*
AddDbContext is Scoped mode (AKA, per request. Once the request is finished, the db context will be disposed)
consider AddDbContextPool, but it has limitation:
* AddDbContextPool is almost equivalent to Singleton, so it cannot accept short lived injection
*/
builder.Services.AddDbContext<MyDbContext>(dbContextBuilder);

builder.Services.AddDbContext<AnotherDbContext>(dbContextBuilder); // when running `dotnet ef migrations add {migration_name}`, need to specify which context the migration will run against


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
