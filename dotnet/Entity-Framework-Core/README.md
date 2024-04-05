[Back](../../README.md)

# Dotnet EF Core Table of Contents

1. [Setup Steps](#setup)
2. [Fluent API](./README_EFCoreFluentAPI.md)
3. [Something about PK](#something-about-pk)
4. [Something about migrations](./README_EFCoreMigration.md)
5. [EF Core Reverse Engineering](./README_EFCoreReverseEngineering.md)
6. [Relationships](./README_EFCoreRelationship.md)
7. [Nuget Packages](#nuget-packages)

# Setup

## Step 1

Create a model

```c#
public class Book
{
  public long Id { get; set; }
  public string Title { get; set; }
  public DateTime PubTime { get; set; }
  public double Price { get; set; }
}
```

## Step 2

Install relevant EF Core packages (In this example, MySQL is used)

- `MySql.EntityFrameworkCore`

NOTE: Installing this package will trigger lots of other packages to be installed. But those extra packages are not listed in .csproj file

## Step 3 (optional)

### Fluent API

Create Config class that inherits from `IEntityTypeConfiguration<TargetModel>`

```c#
public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.ToTable("T_Books"); // specify table name
  }
}
```

NOTE: there are other ways to do the configuration

### In OnModelCreating() in DbContext

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
  base.OnModelCreating(modelBuilder);
  modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); // load all IEntityTypeConfiguration

  modelBuilder.Entity<Book>().ToTable("T_Books");
}
```

### Use data annotation in the model

```c#
[Table("T_Books")]
public class Book
{
  public long Id { get; set; }
  public string Title { get; set; }
  public DateTime PubTime { get; set; }
  public double Price { get; set; }
  public string Author { get; set; }

  public override string ToString()
  {
    return $"Id={Id}, Title={Title}, PubTime={PubTime}, Price={Price}, Author={Author}";
  }
}

```

## Step 4

Create a class that inherits from `DbContext`

```c#
public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }
  public DbSet<Person> Persons { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseMySQL("YourConnectionString");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
  }
}

```

## Step 5

### Step 5.0 (optional)

Run `dotnet tool install --global dotnet-ef` to install dotnet ef tool

Install `Microsoft.EntityFrameworkCore.Design` package to the project

### Step 5.1 Add migration

Run `dotnet ef migrations add your_migration_name`

After running the command, you will find there is a new folder `Migrations` is created. Under that directory, there are migration files

## Step 6

Run `dotnet ef database update` to apply the migration

[back to top](#dotnet-ef-core-table-of-contents)

# Something about PK

EF Core supported PK:

- Auto Incremental
  - Cannot manually assign value to PK
  - PK will be assigned automatically after save
- GUID
  - Cannot set the PK as clustered index
    - clustered index is an index which defines the physical order in which table records are stored in a database
- Hi/Lo Algorithm (check if the target DB supports this before use)
  - Optimize auto incremental
- Hybrid (auto incremental + GUID)
  - Auto incremental as physical PK
  - GUID as logical PK

# Nuget Packages

PostgresSQL: Npgsql.EntityFrameworkCore.PostgresSQL
MySql: Pomelo.EntityFrameworkCore.MySql
SqlServer: Microsoft.EntityFrameworkCore.SqlServer
Oracle: Oracle.EntityFrameworkCore
