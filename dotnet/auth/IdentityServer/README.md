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

## JWT

- header: algorithm
- payload: username, role
- signature: header + payload + key (only server knows)

### Nuget Package

- `System.IdentityModel.Tokens.Jwt`

### Use JwtSecurityTokenHandler to decode JWT
