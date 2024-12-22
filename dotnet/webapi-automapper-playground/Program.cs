using System.Reflection;
using webapi_automapper_playground.Helpers;
using webapi_automapper_playground.Services;
using webapi_automapper_playground.Services.Feature1;
using webapi_automapper_playground.Services.Search.Processors;

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


builder.Services.AddScoped<ISearchProcessorFactory, SearchProcessorFactory>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IBaseSearchProcessor, Activity1SearchProcessor>();
builder.Services.AddScoped<IBaseSearchProcessor, Activity2SearchProcessor>();

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
