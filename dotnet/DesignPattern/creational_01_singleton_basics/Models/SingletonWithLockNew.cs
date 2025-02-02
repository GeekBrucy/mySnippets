using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creational_01_singleton_basics.Models
{
  public class SingletonWithLockNew
  {
    private static readonly Lazy<SingletonWithLockNew> _instance = new(() => new SingletonWithLockNew());
    public static SingletonWithLockNew Instance => _instance.Value;
    private SingletonWithLockNew() { }
  }
}