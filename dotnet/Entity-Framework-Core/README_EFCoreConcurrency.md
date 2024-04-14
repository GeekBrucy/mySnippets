[back](README.md)

# Concurrency Table of Content

# Official Site

https://learn.microsoft.com/en-us/ef/core/saving/concurrency?tabs=data-annotations#optimistic-concurrency

# Pessimistic concurrency

EF Core doesn't have Pessimistic concurrency solution. To handle the pessimistic concurrency, DB lock can be used.
`var article = _ctx.Articles.FromSqlInterpolated($"select * from articles where id = 1 for update").First();`

The `select * from articles where id = 1 for update` part may vary based on DB.

This is not recommended because it is not easy to maintain

# Optimistic concurrency

## SQL Server, AKA the native database

Either `Timestamp` attribute or `IsRowVersion()` with Fluent API can be used

`Timestamp` attribute:

```c#
public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }
}
```

`IsRowVersion()` with Fluent API:

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Person>()
        .Property(p => p.Version)
        .IsRowVersion();
}
```

NOTE: the timestamp still can be used in other database, but the accuracy may not be as good as SQL Server

## Other databases

Set RowVersion as Guid, and manually reset it when updating
