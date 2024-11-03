using System.Reflection;
using ef_core_with_mapper_lib.DBContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
Action<DbContextOptionsBuilder> dbContextBuilder = opt =>
{
    var connStr = builder.Configuration.GetConnectionString("postgres");

    opt.UseNpgsql(connStr, x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
};

builder.Services.AddDbContext<AppDBContext>(dbContextBuilder);

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
