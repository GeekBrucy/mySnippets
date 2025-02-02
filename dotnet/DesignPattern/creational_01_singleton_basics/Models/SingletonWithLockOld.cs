using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creational_01_singleton_basics.Models
{
  public class SingletonWithLockOld
  {
    /*
    volatile: indicate that a field may be modified by multiple threads at the same time. It ensures that the value is always read from and written to the main memory, rather than being cached in CPU registers.

    This is old fashion
    */
    private static volatile SingletonWithLockOld instance = null;
    private static object lockHelper = new object();

    private SingletonWithLockOld() { }

    public static SingletonWithLockOld Instance
    {
      get
      {
        if (instance == null)
        {
          lock (lockHelper)
          {
            if (instance == null) // double check
            {
              instance = new SingletonWithLockOld();
            }
          }
        }

        return instance;
      }
    }
  }
}