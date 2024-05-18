using Microsoft.Extensions.Logging.ApplicationInsights;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// https://learn.microsoft.com/en-us/azure/azure-monitor/app/ilogger?tabs=dotnet6#aspnet-core-applications
builder.Logging.AddApplicationInsights(
    configureTelemetryConfiguration: (config) =>
        config.ConnectionString = builder.Configuration.GetConnectionString("app_insight_sandbox"),
        configureApplicationInsightsLoggerOptions: (options) => { }
);

builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("Bruce Logging", LogLevel.Trace);

var app = builder.Build();
var logger = app.Services.GetService<ILogger<Program>>();
app.Use(async (context, next) =>
{
    logger.LogInformation($"LogInformation: From {context.Connection.RemoteIpAddress}: {context.Request.Path}");
    logger.LogTrace($"LogTrace: From {context.Connection.RemoteIpAddress}: {context.Request.Path}");
    await next();
});

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
