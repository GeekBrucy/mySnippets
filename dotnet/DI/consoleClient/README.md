# Dependency Injection

## Vanilla dotnet

1. Install package `Microsoft.Extensions.DependencyInjection`

```
dotnet add package Microsoft.Extensions.DependencyInjection
```

This package provides access to the IServiceCollection interface which exposes a System.IServiceProvider from which you can call GetService<TService>

2. `Using Microsoft.Extensions.DependencyInjection`

3. ServiceCollection

## Differences among Transient, Scoped and Singleton

- Transient objects are always different; a new instance is provided to every controller and every service.

- Scoped objects are the same within a request, but different across different requests.

- Singleton objects are the same for every object and every request.
