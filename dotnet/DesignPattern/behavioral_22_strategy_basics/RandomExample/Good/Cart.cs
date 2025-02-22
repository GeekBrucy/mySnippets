using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_22_strategy_basics.RandomExample.Good
{
    public class Cart
    {
        IProcessStrategy _processStrategy;
        public Cart(IProcessStrategy processStrategy)
        {
            _processStrategy = processStrategy;
        }

        public void Process()
        {
            _processStrategy.Process();
        }
    }
}