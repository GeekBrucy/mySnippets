using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.Good
{
    public interface IAccountObserver
    {
        void Update(UserAccountArgs args);
    }
}