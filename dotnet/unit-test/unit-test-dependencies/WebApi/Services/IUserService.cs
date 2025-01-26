using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IUserService
    {
        string GetUserName(int userId);
    }
}