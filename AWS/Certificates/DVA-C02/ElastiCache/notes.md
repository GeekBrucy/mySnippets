- Amazon ElastiCache offers fully managed **Redis** and **Memcached**. Seamlessly deploy, run, and scale popular open source compatible in-memory data stores. Build data-intensive apps or improve the performance of your existing apps by retrieving data from high throughput and low latency in-memory data stores. Amazon ElastiCache is a popular choice for Gaming, Ad-Tech, Financial Services, Healthcare, and IoT apps.

# Caching Strategies
- [doc](https://docs.aws.amazon.com/AmazonElastiCache/latest/dg/Strategies.html)

## Lazy loading
- allows for stale data but won’t fail with empty nodes

## Write-through
- Ensures that data is always fresh but may fail with empty nodes and may populate the cache with superfluous data

## Adding TTL
- By adding a time to live (TTL) value to each write, we are able to enjoy the advantages of each strategy and largely avoid cluttering up the cache with superfluous data.