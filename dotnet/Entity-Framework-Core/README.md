[Back](../../README.md)

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
