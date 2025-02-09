using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using creational_05_prototype_basics.Models.Abstracts;

namespace creational_05_prototype_basics.Models.Concrete
{
  public class WalkingEnemyA : AbstractWalkingEnemy
  {
    public override AbstractBaseEnemy Clone()
    {
      /*
        return (WalkingEnemyA)MemberwiseClone();

        MemberwiseClone is shallow copy, it works fine with primitives.

        However for reference type, like object, array etc., it clones its address
      */

      return JsonSerializer.Deserialize<WalkingEnemyA>(JsonSerializer.Serialize(this));
    }
  }
}