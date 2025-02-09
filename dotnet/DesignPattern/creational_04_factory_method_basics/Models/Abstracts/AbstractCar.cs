using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creational_04_factory_method.Models.Abstracts
{
  public abstract class AbstractCar
  {
    public abstract void Startup();
    public abstract void Run();
    public abstract void Turn(string direction);
    public abstract void Stop();
  }
}