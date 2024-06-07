using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_mediatR_demo.Interfaces;
using _02_mediatR_demo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _02_mediatR_demo.Data;

public class MyDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  private readonly IMediator _mediator;

  public MyDbContext(DbContextOptions<MyDbContext> options, IMediator mediator) : base(options)
  {
    _mediator = mediator;
  }
  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    var domainEntities = ChangeTracker.Entries<IDomainEvents>()
      .Where(x => x.Entity.GetDomainEvents().Any()); // get all IDomainEvents that have unpublished events

    var domainEvents = domainEntities.SelectMany(x => x.Entity.GetDomainEvents()).ToList();
    domainEntities.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());

    foreach (var domainEvent in domainEvents)
    {
      await _mediator.Publish(domainEvent);
    }

    return await base.SaveChangesAsync(cancellationToken);
  }
}
