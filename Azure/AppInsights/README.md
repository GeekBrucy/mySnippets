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

# Infrastructure

## Clear App insight logs

https://learn.microsoft.com/en-us/answers/questions/1106390/who-can-delete-modify-the-logs-stored-in-applicati

1. **Before the data is ingested into Azure Log Analytics / Application Insights ** - Anyone who can modify the code prior to ingestion via the Application Insights SDK
2. Once inside Application Insights (Classic Model) - Anyone with the permissions to run the Application Insights Purge API can delete the data (not modify).
3. Once inside Application Insights (Workspace Model) - Anyone with the permissions to run the Workspace Purge API can delete the data (not modify).

Both Application Insights and Workspace purge API requires the `Data Purger` role to be able to execute this. Having the owner role is NOT sufficient enough.
