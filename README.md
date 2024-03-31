# mySnippets

# Dotnet auth tute

[Official Doc - Create Starter App](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-8.0#create-the-starter-app)

# Step 1

Run `dotnet new webapp -o ContactManager -au Individual`

- -au: The type of authentication to use
- -uld: Whether to use LocalDB instead of SQLite (this may not be needed)

# Step 2

Run `dotnet new gitignore` to avoid committing useless stuff

# Step 3

Create Contact Model

# Step 4

Create initial migration and update the databsae

```bash
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet-aspnet-codegenerator razorpage -m Contact -udl -dc ApplicationDbContext -outDir Pages\Contacts --referenceScriptLibraries -sqlite
dotnet ef database drop -f
dotnet ef migrations add initial
dotnet ef database update
```

# dotnet commands:

## Add projects to solution

`dotnet sln add .\YourProject\YourProject.csproj`

Why do we add `sln` file?

- restoring/building all project
- run from project (`dotnet run --project YourProject`)

## Add reference to project

`dotnet add Target/Target.csproj reference .\Source\Source.csproj`

The command above means add `Source` project reference to `Target` project.

Alternatively, cd to the target directory, and do
`dotnet add reference DesiredProject/DesiredProject.csproj`

## Run a project at solution root level

`dotnet run --project YourProjectName`

# dotnet useful lib:

## MailKit

Open source email service

## Autofac

3rd party DI lib

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
