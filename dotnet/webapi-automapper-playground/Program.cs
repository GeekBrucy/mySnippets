using System.Reflection;
using webapi_automapper_playground.Helpers;
using webapi_automapper_playground.Services;
using webapi_automapper_playground.Services.Feature1;
using webapi_automapper_playground.Services.Feature1.Feature1Functions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper
(
    opt => opt.AddMaps(Assembly.GetExecutingAssembly())
);


builder.Services.AddScoped<IFeature1FunctionFactory, Feature1FunctionFactory>();
builder.Services.AddScoped<IFeature1Service, Feature1Service>();
builder.Services.AddScoped<IBaseFeature1Function<Feature1Function1>, Feature1Function1>();

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
