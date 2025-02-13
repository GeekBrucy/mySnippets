using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_09_decorator_basics.Good.Models.Abstracts;

namespace structural_09_decorator_basics.Good.Models.Concrete
{
    public class DecoratorB : Decorator
    {
        public DecoratorB(Tank tank) : base(tank)
        {
        }

        public override void Run()
        {
            // extend Run with B feature
            Console.WriteLine("extend run with B feature");
            base.Run();
        }

        public override void Shot()
        {
            // extend shot with B feature
            Console.WriteLine("extend shot with B feature");
            base.Shot();
        }
    }
}