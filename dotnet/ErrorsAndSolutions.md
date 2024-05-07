# Dotnet ef migration issue (with Identity Server)

## Error message:

Unable to create an object of type '{your db context name}'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

### Background

The db context inherit from `IdentityDbContext` (from Identity Server).

```c#
public class MyDbContext : IdentityDbContext
{
  public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
  {
  }
}
```

- Customized User model

```c#
public class CustomUser : IdentityUser<long>
{

}
```

- Customized Role model

```c#
public class CustomRole : IdentityRole<long>
{

}
```

The error shows when trying to create the migrations

## Solution 1 (Maybe for identity server only)

In the db context, make it inherit from `IdentityDbContext<CustomUser, CustomRole, long>` or whichever suits your need

## Solution 2 (in general)

Create `DbContextDesignTimeFactory` that inherits from `IDesignTimeDbContextFactory<YourDbContext>`

```c#
public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<MyDbContext>
{
  public MyDbContext CreateDbContext(string[] args)
  {
    DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
    builder.UseNpgsql("conn string");

    return new MyDbContext(builder.Options);
  }
}
```

# JWT Token keeps returning 401

## Possible cause 1

Wrong credentials or invalid user

## Possible cause 2

Wrong JWT format.

## Possible cause 3

Compromised security key

# Azure durable function deadlock

The durable function will apply lease some file in storage account. Sometimes, there will be some conflicts when acquiring lease.

## Possible cause 1

- Lease management

## Possible cause 2

- Multiple function apps associate with same storage account

## Solution

- Try to implement 1 storage account per function app
- Upgrade durable function nuget package
- Upgrade storage account sdk
