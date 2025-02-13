using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_09_decorator_basics.Good.Models.Abstracts;

namespace structural_09_decorator_basics.Models.Good.Concrete
{
    public class DecoratorC : Decorator
    {
        public DecoratorC(Tank tank) : base(tank)
        {
        }

        public override void Run()
        {
            Console.WriteLine("extend run with C feature");
            base.Run();
        }

        public override void Shot()
        {
            Console.WriteLine("extend shot with C feature");
            base.Shot();
        }
    }
}