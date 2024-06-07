using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_mediatR_demo.Interfaces;
using MediatR;

namespace _02_mediatR_demo.Models;

public abstract class BaseEntity : IDomainEvents
{
  private readonly IList<INotification> _events = new List<INotification>();
  public void AddDomainEvent(INotification eventItem)
  {
    _events.Add(eventItem);
  }

  public void AddDomainEventIfAbsent(INotification eventItem)
  {

  }

  public void ClearDomainEvents()
  {
    _events.Clear();
  }

  public IEnumerable<INotification> GetDomainEvents()
  {
    return _events;
  }
}
