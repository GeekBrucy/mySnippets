# Hosted Service

If there is exceptions in the hosted service, the entire application will exit.

Set `HostOptions.BackgroundServiceExceptionBehavior` to `Ignore` (Not recommended). Alternatively, user `try...catch`

# DI

Hosted service is registered as singleton, so `scoped` or `transient` service cannot be injected to the hosted service. If those short lived services are required, inject `IServiceScopeFactory` to it. Use `IServiceScopeFactory` to create an `IServiceScope` object (need to dispose it)
