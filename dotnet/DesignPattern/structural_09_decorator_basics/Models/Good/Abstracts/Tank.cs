using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_09_decorator_basics.Good.Models.Concrete;

namespace structural_09_decorator_basics.Good.Models.Abstracts
{
    public abstract class Tank
    {
        public abstract void Shot();
        public abstract void Run();
    }
}