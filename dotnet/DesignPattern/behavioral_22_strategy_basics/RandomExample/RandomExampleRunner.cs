using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using behavioral_22_strategy_basics.RandomExample.Good;

namespace behavioral_22_strategy_basics.RandomExample
{
    public class RandomExampleRunner
    {
        public static void Run()
        {
            Cart cart = new Cart(new ProcessStrategyA());
            cart.Process();
            cart = new Cart(new ProcessStrategyB());
            cart.Process();
        }
    }
}