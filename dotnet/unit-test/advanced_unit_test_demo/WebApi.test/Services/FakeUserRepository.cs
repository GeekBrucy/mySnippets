using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.test.Services
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly string _email;
        private readonly string _password;
        public int UpdateAsyncInvokedCounter { get; set; }
        public FakeUserRepository(string email, string password)
        {
            _email = email;
            _password = password;
        }
        public Task<User[]> GetAllUserAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            if (_email == email)
            {
                return Task.FromResult(new User(email, _password));
            }
            else
            {
                return Task.FromResult<User?>(null);
            }
        }

        public Task<Guid> InsertAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            UpdateAsyncInvokedCounter++;
            return Task.CompletedTask;
        }
    }
}