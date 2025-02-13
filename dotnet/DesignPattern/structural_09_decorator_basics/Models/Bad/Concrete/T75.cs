using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_09_decorator_basics.Bad.Models.Abstracts;

namespace structural_09_decorator_basics.Bad.Models.Concrete
{
  public class T75 : Tank
  {
    public override void Run()
    {
      Console.WriteLine("T75 Run");
    }

    public override void Shot()
    {
      Console.WriteLine("T75 Shot");
    }
  }
}