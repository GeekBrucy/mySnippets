# Dotnet in general

## Architecture Docs

https://learn.microsoft.com/en-us/dotnet/architecture/microservices/

## Database options for development

https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli

- In Memory Database: Nuget package `Microsoft.EntityFrameworkCore.InMemory` (no migration needed)

## EF Core TransactionScope

- ThreadLocal
- AsyncLocal

## Useful Nuget

- Dynamic.Json: resolve the json to dynamic type
- Ude.NetStandard: detect charset of the file
- MarkdownSharp: convert markdown text to html text
- MailKit: Open source email service
- Autofac: 3rd party DI lib

# dotnet commonly used packages

## Dependency Injection

`dotnet add package Microsoft.Extensions.DependencyInjection`

## Configuration

`dotnet add package Microsoft.Extensions.Options`

`dotnet add package Microsoft.Extensions.Configuration`

`dotnet add package Microsoft.Extensions.Configuration.Binder`
Binder package allows to bind the config to a class

`dotnet add package Microsoft.Extensions.Configuration.Json`

`Microsoft.Extensions.Configuration.CommandLine` Add config via command line arguments

`Microsoft.Extensions.Configuration.EnvironmentVariables` for environment variable config

# dotnet csproj configs

## Copy file to build

Add the following to the .csproj file

```
<ItemGroup>
  <Content Include="Your file name">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </Content>
</ItemGroup>
```
