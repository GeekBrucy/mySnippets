# Cache concepts

- Cache Hit

- Cache Hit Rate

- Cache consistency

## Client Cache (AKA browser)

### cache-control

Format: `cache-control:max-age=60` - Cache this response for 60 seconds

#### Using `ResponseCacheAttribute` in WebAPI

`ResponseCacheAttribute` will automatically add `cache-control` header in the response

NOTE: this can be disabled by the client (browser)

## Server Side Cache

In dotnet webapi, server side cache is not enabled. To enable it, add `app.UseResponseCaching()` BEFORE `app.MapControllers()`.

If CORS is enabled, make sure `app.UseCors()` is before `app.UseResponseCaching()`,

NOTE: this can be disabled by the client (browser)

## Why the client can disable cache?

From the client, it can include a header `cache-control:no-cache`, the server side or the client side will respect the value and not to response with the cache value.
