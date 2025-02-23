using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
            if (user == null)
            {
                throw new Exception("email not found");
            }

            if (!user.ValidatePassword(oldPassword))
            {
                return false;
            }

            user.ChangePassword(newPassword);
            await _userRepository.UpdateAsync(user, CancellationToken.None);
            return true;
        }
    }
}