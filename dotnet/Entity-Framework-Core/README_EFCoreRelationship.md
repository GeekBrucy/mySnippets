[back](README.md)

# EF Core Relationship Table of Contents

# Official Doc

https://learn.microsoft.com/en-us/ef/core/modeling/relationships

# One to Many Config

`HasOne(...).WithMany(...);`

Example Classes:

```c#
public class Article
{
  public long Id { get; set; }
  public string Title { get; set; }
  public string Message { get; set; }
  public List<Comment> Comments = new List<Comment>();
}

public class Comment
{
  public long Id { get; set; }
  public string Message { get; set; }
  public Article Article { get; set; }
}
```

Apply one to many config to `Comment`

```c#
public class CommentConfig : IEntityTypeConfiguration<Comment>
{
  public void Configure(EntityTypeBuilder<Comment> builder)
  {
    builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments);
  }
}
```

Apply one to many config to `Article`

# One to One Config

`HasOne(...).WithOne(...);`

NOTE: A foreign key property must be explicitly declared in one of the entities

```c#
public class Order
{
  public long Id { get; set; }
  public string Name { get; set; }
  public string Address { get; set; }
  public Delivery Delivery { get; set; }
}

```

```c#
public class Delivery
{
  public long Id { get; set; }
  public string CompanyName { get; set; }
  public string Number { get; set; }
  public Order Order { get; set; }
  public long OrderId { get; set; }
}
```

```c#
public class OrderConfig : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.HasOne<Delivery>(o => o.Delivery).WithOne(d => d.Order)
      .HasForeignKey<Delivery>(d => d.OrderId); // this must be declared
  }
}
```

## Self reference

# Many to Many Config (available in EF Core 5.0 or later version)

`HasMany(...).WithMany(...);`

```c#
public class Student
{
  public long Id { get; set; }
  public string Name { get; set; }
  public List<Teacher> Teachers { get; set; } = new List<Teacher>();
}

```

```c#
public class Teacher
{
  public long Id { get; set; }
  public string Name { get; set; }
  public List<Student> Students { get; set; } = new List<Student>();
}
```

```c#
public class StudentConfig : IEntityTypeConfiguration<Student>
{
  public void Configure(EntityTypeBuilder<Student> builder)
  {
    builder.HasMany<Teacher>(s => s.Teachers).WithMany(t => t.Students);
    // .UsingEntity(r => r.ToTable("R_Students_Teachers"))
  }
}
```
