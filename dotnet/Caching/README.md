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
