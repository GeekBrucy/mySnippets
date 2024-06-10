using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.Entities;
using Users.Domain.ValueObjects;

namespace Users.Domain.Interfaces.Repository;

public interface IUserRepository
{
  Task<User?> FindOneAsync(PhoneNumber phoneNumber);
  Task<User?> FindOneAsync(Guid userId);
  Task AddNewLoginHistory(PhoneNumber phoneNumber, string message);
  Task SavePhoneNumberCodeAsync(PhoneNumber phone, string code);
  Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phoneNumber);
  Task PublishEventAsync(UserAccessResultEvent e);
}
