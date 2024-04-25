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

## In-Memory Cache

1. `builder.Services.AddMemoryCache()`
2. DI `IMemoryCache` interface. (Interface functions: TryGetValue, Remove, Set, GetOrCreate, GetOrCreateAsync)

### GetOrCreateAsync

1. Get data from Cache
2. Fetch data from data source and return to caller

### Cache expire strategy

#### Remove or Set cache when the data is changed

#### Set expire time

- Absolute expiration
- Sliding expiration

### Cache Penetration

#### Cause

Attacker keeps fetching the data that does not exist in the database. This will cause the cache always to be `null`

Consider the following snippet

```c#
string cacheKey = "Book " + id;
Book? b = memCache.Get<Book?>(cacheKey);
if (b == null)
{
  b = await dbCtx.Books.FindAsync(id); // there is no data with the given id
  memCache.Set(cacheKey); // the cache is set to null
}
```

#### Solution

Use `GetOrCreateAsync` to treat `null` as cache hit

### Cache Avalanche

#### Cause

Caches are expired almost at the same time. For example, 100 records all expire in 30 seconds, which could spike the server/DB specs

#### Solution

Add random expire time on top of base time span

```c#
...
e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(Random.Shared.Next(10, 15));
...
```

## Distributed Cache

Cached values are all `byte[]`

### Common Distributed Cache Server

- Redis: NuGet `Microsoft.Extensions.Caching.StackExchangeRedis`
- Memcached

### Relevant interface

- IDistributedCache
