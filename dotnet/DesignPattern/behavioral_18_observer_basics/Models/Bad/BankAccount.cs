using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.Bad
{
    public class BankAccount
    {
        Email _email;       // 强依赖关系 ❌
        Mobile _mobile;     // 强依赖关系 ❌
        public void Withdraw(int amount)
        {
            // do withdraw
            _email.SendEmail($"withdraw {amount}");
            _mobile.SendMessage($"withdraw {amount}");
        }
    }
}