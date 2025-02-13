using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_09_decorator_basics.Good.Models.Abstracts;

namespace structural_09_decorator_basics.Good.Models.Concrete
{
    public class DecoratorA : Decorator
    {
        public DecoratorA(Tank tank) : base(tank)
        {
        }

        public override void Shot()
        {
            // extend shot with A feature
            Console.WriteLine("extend shot with A feature");
            base.Shot();
        }

        public override void Run()
        {
            // extend run with A feature
            Console.WriteLine("extend run with A feature");
            base.Run();
        }
    }
}