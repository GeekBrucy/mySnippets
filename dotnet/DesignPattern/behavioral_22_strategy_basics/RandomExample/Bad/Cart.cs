using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_22_strategy_basics.RandomExample.Bad
{
    public class Cart
    {
        protected virtual void ProcessA() { }
        protected virtual void ProcessB() { }
        protected virtual void ProcessC() { }
        public void GetAlignment(CartType cartType)
        {
            switch (cartType)
            {
                case CartType.A:
                    ProcessA();
                    break;
                case CartType.B:
                    ProcessB();
                    break;
                case CartType.C:
                    ProcessC();
                    break;
                default:
                    throw new ArgumentException("Invalid cart type");
            }
        }
    }
}