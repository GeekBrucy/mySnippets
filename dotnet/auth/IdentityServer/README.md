# Identity Core

## NuGet

`Microsoft.AspNetCore.Identity.EntityFrameworkCore`

## User, Role Entities

### Out of box

- IdentityUser<TKey>
- IdentityRole<TKey>

`TKey` is the Primary Key type

Normally, create a custom User/Role model and inherit from `IdentityUser`/`IdentityRole`

Inherit custom DbContext from `IdentityDbContext`
