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

## Self reference

# Many to Many Config

`HasMany(...).WithMany(...);`
