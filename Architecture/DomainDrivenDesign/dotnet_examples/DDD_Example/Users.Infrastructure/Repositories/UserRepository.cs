using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Repository;
using Users.Domain.ValueObjects;
using Users.Infrastructure.Data;

namespace Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  private readonly UserDbContext _dbContext;
  private readonly IDistributedCache _cache;
  private readonly IMediator _mediator;

  public UserRepository(UserDbContext dbContext, IDistributedCache cache, IMediator mediator)
  {
    _dbContext = dbContext;
    _cache = cache;
    _mediator = mediator;
  }
  public async Task AddNewLoginHistory(PhoneNumber phoneNumber, string message)
  {
    User? user = await FindOneAsync(phoneNumber);
    Guid? userId = null;
    if (user != null)
    {
      userId = user.Id;
    }
    _dbContext.UserLoginHistories.Add(new UserLoginHistory(userId, phoneNumber, message));
  }

  public async Task<User?> FindOneAsync(PhoneNumber phoneNumber)
  {
    return await _dbContext.Users.Include(u => u.AccessFail).SingleOrDefaultAsync(u => u.PhoneNumber.Number == phoneNumber.Number && u.PhoneNumber.RegionCode == phoneNumber.RegionCode);
  }

  public async Task<User?> FindOneAsync(Guid userId)
  {
    return await _dbContext.Users.Include(u => u.AccessFail).SingleOrDefaultAsync(u => u.Id == userId);
  }

  public async Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phone)
  {
    string key = $"PhoneNumberCode_{phone.RegionCode}_{phone.Number}";

    string? code = await _cache.GetStringAsync(key);
    _cache.Remove(key);

    return code;
  }

  public Task PublishEventAsync(UserAccessResultEvent e)
  {
    return _mediator.Publish(e);
  }

  public Task SavePhoneNumberCodeAsync(PhoneNumber phone, string code)
  {
    string key = $"PhoneNumberCode_{phone.RegionCode}_{phone.Number}";

    return _cache.SetStringAsync(key, code, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
  }
}
