using _01_Basic.Data;
using _01_Basic.Middlewares;
using _01_Basic.Models;
using Azure.Identity;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging.ApplicationInsights;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AzureSearch>(builder.Configuration.GetSection("AzureSearch"));
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    var connStr = builder.Configuration.GetConnectionString("sql_conn_str");

    opt.UseSqlServer(connStr);
});

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(new Uri("https://padil-poc-key-vault.vault.azure.net/"));
    clientBuilder.UseCredential(new DefaultAzureCredential());
});
// https://learn.microsoft.com/en-us/azure/azure-monitor/app/ilogger?tabs=dotnet6#aspnet-core-applications
// builder.Logging.AddApplicationInsights(
//     configureTelemetryConfiguration: (config) =>
//         config.ConnectionString = builder.Configuration.GetSection("app_insight_sandbox").Value,
//         configureApplicationInsightsLoggerOptions: (options) => { }
// );

// builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("Bruce Logging", LogLevel.Trace);

var app = builder.Build();
var logger = app.Services.GetService<ILogger<Program>>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
