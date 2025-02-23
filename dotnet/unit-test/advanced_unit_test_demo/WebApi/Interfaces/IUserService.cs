using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IUserService
    {
        Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword, CancellationToken cancellationToken);
    }
}