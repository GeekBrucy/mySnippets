[Back](README.md)

# Fluent API Table of Contents

1. [View projection](#entity-view-projection)
2. [Ignore property](#ignore-property)
3. [Set column name](#set-column-name)
4. [Set column type](#set-column-type)
5. [Set primary key](#set-primary-key)
6. [Generate column value on operations](#generate-column-value-on-operations)
7. [Set default value](#set-default-value)
8. [Set index](#set-index)

## Entity View Projection

```c#
public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ...
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    ...
    modelBuilder.Entity<Book>().ToView("BookView");
  }
}
```

or

```c#
public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    ...
    builder.ToView("BookView");
  }
}

```

## Ignore property

```c#
public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ...
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    ...
    modelBuilder.Entity<Book>().Ignore(b => b.Price);
  }
}
```

or

```c#
public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    ...
    builder.Ignore(b => b.Price);
  }
}

```

## Set column name

```c#
public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ...
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    ...
    modelBuilder.Entity<Book>().Property(b => b.Id).HasColumnName("book_id");
  }
}
```

or

```c#
public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    ...
    builder.Property(b => b.Id).HasColumnName("bookId");
  }
}
```

## Set column type

```c#
public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ...
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    ...
    modelBuilder.Entity<Book>().Property(b => b.Id).HasColumnType("varchar(200)");
  }
}
```

or

```c#
public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.Property(b => b.Id).HasColumnType("varchar(200)");
  }
}
```

## Set primary key

```c#
public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ...
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    ...
    modelBuilder.Entity<Book>().HasKey(b => b.PubTime);
  }
}
```

or

```c#
public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.HasKey(b => b.PubTime);
  }
}

```

## Generate column value on operations

```c#
public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ...
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    ...
    modelBuilder.Entity<Book>().Property(b => b.Price).ValueGeneratedOnAdd();
  }
}
```

or

```c#
public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.Property(b => b.Price).ValueGeneratedOnAdd();
  }
}

```

## Set default value

`modelBuilder.Entity<Book>().Property(b => b.Price).HasDefaultValue(123);`

`builder.Property(b => b.Price).HasDefaultValue(123);`

## Set index

`modelBuilder.Entity<Book>().HasIndex(b => b.Id);`
`modelBuilder.Entity<Book>().HasIndex(b => b.Id).IsUnique();`

`builder.HasIndex(b => b.Id);`
`builder.HasIndex(b => b.Id).IsUnique();`

### multiple indexes:

`modelBuilder.Entity<Book>().HasIndex(b => new {b.Id, b.Price});`

`builder.HasIndex(b => new {b.Id, b.Price});`

[back to top](#fluent-api-table-of-contents)
