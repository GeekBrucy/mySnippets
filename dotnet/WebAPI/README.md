# API

## Two style

### RPC

#### Format

`{controller}/{method}`, for example: `/Persons/GetAll`, `/Persons/GetById?id=8`, `/Persons/Update`, `Persons/DeleteById/7`

This style doesn't care http verb

### REST

Based on HTTP verb to use HTTP protocol

- URL for locating resource
- Verb: GET, POST, PUT, DELETE, PATCH
  - Idempotent: DELETE, PUT, GET
  - Non-idempotent: POST
- [Status code](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status)

## Dependency Injection

```c#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
```

`CreateBuilder` will make `IServiceCollection` accessible.

### FromServices

If the service is only used in one API in the controller, use `[FromServices]` attribute

```c#
[HttpGet]
public int RunSlowService([FromServices] SlowService slowService)
{
  return slowService.Count;
}
```
