using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_09_decorator_basics.Bad.Models.Abstracts;
using structural_09_decorator_basics.Interfaces;

namespace structural_09_decorator_basics.Bad.Models.Concrete
{
  public class T50 : Tank, IA
  {
    public override void Run()
    {
      ((IA)this).RunA();
      Console.WriteLine("T75 Run");
    }

    public override void Shot()
    {
      ((IA)this).ShotA();
      Console.WriteLine("T75 Shot");
    }

    void IA.RunA()
    {
      Console.WriteLine("T50 RunA");
    }

    void IA.ShotA()
    {
      Console.WriteLine("T50 ShotA");
    }
  }
}