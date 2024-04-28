# Pitfalls

## Migrations

The migrations cannot be create without a config in `Program.cs`:

```c#
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    var connStr = builder.Configuration.GetConnectionString("postgres");

    opt.UseNpgsql(connStr, x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)); // <--- this
});
```

Otherwise, it will throw error:

```
Your target project '{The project that references the db context}' doesn't match your migrations assembly '{The db context project}'. Either change your target project or change your migrations assembly.
Change your migrations assembly by using DbContextOptionsBuilder. E.g. options.UseSqlServer(connection, b => b.MigrationsAssembly("{The project that references the db context}")). By default, the migrations assembly is the assembly containing the DbContext.
Change your target project to the migrations project by using the Package Manager Console's Default project drop-down list, or by executing "dotnet ef" from the directory containing the migrations project.
```

NOTE: Nuget package: `Microsoft.EntityFrameworkCore.Design` is needed in the main project (not db context project)
