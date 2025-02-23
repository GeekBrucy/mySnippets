using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        private User() { }

        public User(string email, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
        }
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
        public bool ValidatePassword(string password)
        {
            return Password == password;
        }
    }
}