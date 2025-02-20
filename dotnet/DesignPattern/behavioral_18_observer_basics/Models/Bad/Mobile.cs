using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.Bad
{
    public class Mobile
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Message sent: {message}");
        }
    }
}