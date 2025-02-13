using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_09_decorator_basics.Good.Models.Abstracts
{
    public abstract class Decorator : Tank // Do-As, not Is-A. It acts like interface inheritance
    {
        private Tank _tank; // Has-A

        public Decorator(Tank tank)
        {
            _tank = tank;
        }

        public override void Run()
        {
            _tank.Run();
        }

        public override void Shot()
        {
            _tank.Shot();
        }
    }
}