using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Repository;
using Users.Infrastructure.Data;

namespace Users.WebAPI.EventHandlers;

public class UserAccessResultEventHandler : INotificationHandler<UserAccessResultEvent>
{
  private readonly IUserRepository _userRepository;
  private readonly UserDbContext _userDbContext;
  public UserAccessResultEventHandler(IUserRepository userRepository, UserDbContext userDbContext)
  {
    _userRepository = userRepository;
    _userDbContext = userDbContext;
  }
  public async Task Handle(UserAccessResultEvent notification, CancellationToken cancellationToken)
  {
    await _userRepository.AddNewLoginHistory(notification.PhoneNumber, $"Login Result: {notification.Result}");
    await _userDbContext.SaveChangesAsync();
  }
}
