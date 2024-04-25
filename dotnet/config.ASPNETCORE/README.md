# ASP.NET Core Config

## Get Environment Value

Read from environment variable `ASPNETCORE_ENVIRONMENT`.

Recommended value: `Development`, `Staging`, `Production` etc. It depends on the developer.

Use `app.Environment.EnvironmentName`, `app.Environment.IsDevelopment()` etc. to read the value
