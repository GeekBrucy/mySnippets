using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creational_04_factory_method.Models.Abstracts
{
  public class ToyotaCarFactory : AbstractCarFactory
  {
    public override AbstractCar CreateCar()
    {
      return new Toyota();
    }
  }
}