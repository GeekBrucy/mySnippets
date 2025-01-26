using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Helpers
{
    public class UserGreeting
    {
        private readonly IUserService _userService;

        public UserGreeting(IUserService userService)
        {
            _userService = userService;
        }

        public string GetGreeting(int userId)
        {
            var userName = _userService.GetUserName(userId);
            return $"Hello, {userName}";
        }
    }
}