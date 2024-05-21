# App Insight Github

https://github.com/Microsoft/ApplicationInsights-dotnet?tab=readme-ov-file

# Coding

## Packages to add for Application Insights support:

- Microsoft.ApplicationInsights.AspNetCore - SDK and Auto Collectors for ASP.NET Core applications
- Microsoft.ApplicationInsights.WorkerService - SDK and Auto Collectors for Worker Service or Console applications
- Microsoft.ApplicationInsights - base SDK; Auto Collectors can be installed or implemented additionally
- Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel - for a more reliable telemetry delivery
- Microsoft.Extensions.Logging.ApplicationInsights - log provider for Application Insights

### Serilog Packages

- Serilog - base package
- Serilog.AspNetCore - for ASP.NET Core
- Serilog.Exceptions - for improved exception logging
- Serilog.Extensions.Logging - a Serilog provider for Microsoft.Extensions.Logging
- Serilog.Extensions.Logging.ApplicationInsights - simplifies Application Insights configuration for Serilog
- Serilog.Sinks.ApplicationInsights - adds a Serilog sink to write logs to Application Insights
- Serilog.Expressions - for improved configuration capabilities via config files (an embeddable mini-language for filtering, enriching, and formatting Serilog events, ideal for use with JSON or XML configuration)
- Serilog.Settings.Configuration - Microsoft.Extensions.Configuration (appsettings.json) support for Serilog
- Serilog.Extensions.Hosting - to create a bootstrap logger

#### Enriching log events with additional data:

- Serilog.Enrichers.CorrelationId - add correlation id
- Serilog.Enrichers.Sensitive - automatically mask sensitive data

#### Additional sinks for other logging targets:

- Serilog.Sinks.Async
- Serilog.Sinks.Console
- Serilog.Sinks.File
