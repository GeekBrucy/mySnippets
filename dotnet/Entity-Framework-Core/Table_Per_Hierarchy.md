```c#
public abstract class Activity
{
    public int Id { get; set; }
    public string Discriminator { get; set; } // Required for TPH mapping
}

public class ActivityA : Activity
{
    public virtual ActivityTypeA ActivityTypeA { get; set; }
}

public class ActivityB : Activity
{
    public virtual ActivityTypeB ActivityTypeB { get; set; }
}
```

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Activity>()
        .HasDiscriminator<string>("Discriminator") // Use a column to differentiate types
        .HasValue<ActivityA>("ActivityA")
        .HasValue<ActivityB>("ActivityB");

    modelBuilder.Entity<ActivityA>()
        .HasOne(a => a.ActivityTypeA)
        .WithOne()
        .HasForeignKey<ActivityA>(a => a.Id);

    modelBuilder.Entity<ActivityB>()
        .HasOne(b => b.ActivityTypeB)
        .WithOne()
        .HasForeignKey<ActivityB>(b => b.Id);
}
```