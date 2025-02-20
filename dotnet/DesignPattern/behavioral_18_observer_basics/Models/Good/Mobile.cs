using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.Good
{
    public class Mobile : IAccountObserver
    {
        public void Update(UserAccountArgs args)
        {
            Console.WriteLine($"Message sent to {args.PhoneNumber}: {args.Message}");
        }
    }
}