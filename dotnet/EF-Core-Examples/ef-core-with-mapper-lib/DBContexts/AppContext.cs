using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ef_core_with_mapper_lib.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace ef_core_with_mapper_lib.DBContexts;

public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
  {
  }

  public DbSet<Library> Libraries { get; set; }
  public DbSet<Book> Books { get; set; }
  public DbSet<Chapter> Chapters { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    modelBuilder.Entity<Library>()
        .HasMany(l => l.Books)
        .WithOne(b => b.Library);

    modelBuilder.Entity<Book>()
        .HasMany(b => b.Chapters)
        .WithOne(c => c.Book)
        .HasForeignKey(c => c.BookId)
        .OnDelete(DeleteBehavior.Cascade)
        ;
  }

  public void ConvertDeletesToSoftDeletes()
  {
    // Get entities marked for deletion
    var entriesToDelete = ChangeTracker.Entries()
        .Where(e => e.State == EntityState.Deleted && e.Entity is BaseModel)
        .OrderByDescending(e => GetDepth(e.Entity)) // Ensure depth-first processing
        .ToList();

    foreach (var entry in entriesToDelete)
    {
      // Ensure only deleted entities are modified
      if (entry.State == EntityState.Deleted)
      {
        entry.State = EntityState.Unchanged; // Change the state to Unchanged to keep it tracked
        entry.CurrentValues["IsDeleted"] = true; // Mark IsDeleted as true
        entry.Property("IsDeleted").IsModified = true; // Explicitly mark IsDeleted as modified
      }
    }
  }

  private int GetDepth(object entity)
  {
    // This method calculates the depth of nested entities based on their navigation properties
    var entityType = entity.GetType();
    var navigations = Model.FindEntityType(entityType)?.GetNavigations();

    if (navigations == null || !navigations.Any())
      return 0;

    int maxDepth = 0;
    foreach (var navigation in navigations)
    {
      var relatedEntityType = navigation.ClrType;
      if (typeof(BaseModel).IsAssignableFrom(relatedEntityType))
      {
        maxDepth = Math.Max(maxDepth, 1 + GetDepth(Activator.CreateInstance(relatedEntityType)));
      }
    }

    return maxDepth;
  }

}
