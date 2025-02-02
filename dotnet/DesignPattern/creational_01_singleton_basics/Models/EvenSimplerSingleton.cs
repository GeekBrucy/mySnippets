using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creational_01_singleton_basics.Models
{
  public class EvenSimplerSingleton
  {
    public static readonly EvenSimplerSingleton Instance = new EvenSimplerSingleton();
    private EvenSimplerSingleton() { }
  }

  /*
    The following code is equivalent to above
  */
  public class EvenSimplerSingletonExpanded
  {
    public static readonly EvenSimplerSingletonExpanded Instance;

    static EvenSimplerSingletonExpanded()
    {
      Instance = new EvenSimplerSingletonExpanded();
    }
    private EvenSimplerSingletonExpanded() { }
  }
}