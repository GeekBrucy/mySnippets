# ASP.NET Core Config

## Get Environment Value

Read from environment variable `ASPNETCORE_ENVIRONMENT`. In WebAPI project, it resides in `launchSettings.json`

Recommended value: `Development`, `Staging`, `Production` etc. It depends on the developer.

Use `app.Environment.EnvironmentName`, `app.Environment.IsDevelopment()` etc. to read the value

# Protect sensitive configs

## Use USER SECRETS (Dev only)

[Official Doc](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows)

### Location

`%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`

### CLI

#### Init

`dotnet user-secrets init`

### Useful VSCode Extension

`.NET Core User Secrets`
