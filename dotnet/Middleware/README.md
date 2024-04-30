# Dotnet Middleware

[Official Doc](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-8.0)

# Critical Concepts

## Map

A convention for branching the pipeline

## Use

Chain multiple request delegates together

## Run

Run delegates don't receive a next parameter. The first Run delegate is always terminal and terminates the pipeline. Run is a convention. Some middleware components may expose Run[Middleware] methods that run at the end of the pipeline:
