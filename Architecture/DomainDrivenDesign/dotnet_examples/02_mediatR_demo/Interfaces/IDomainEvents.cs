using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace _02_mediatR_demo.Interfaces;

public interface IDomainEvents
{
  IEnumerable<INotification> GetDomainEvents();
  void AddDomainEvent(INotification eventItem);
  void AddDomainEventIfAbsent(INotification eventItem);
  void ClearDomainEvents();
}
