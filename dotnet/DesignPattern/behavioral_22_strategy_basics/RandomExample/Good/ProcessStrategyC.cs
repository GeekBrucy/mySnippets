using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_22_strategy_basics.RandomExample.Good
{
    public class ProcessStrategyC : IProcessStrategy
    {
        public void Process()
        {
            Console.WriteLine("ProcessStrategyC");
        }
    }
}