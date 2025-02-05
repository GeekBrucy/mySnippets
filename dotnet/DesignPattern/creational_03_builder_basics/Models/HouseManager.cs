using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creational_03_builder_basics.Models.Abstracts;

namespace creational_03_builder_basics.Models
{
  public class HouseManager
  {
    public static AbstractHouse CreateHouse(AbstractBuilder builder)
    {
      builder.BuildDoor();
      builder.BuildDoor();

      builder.BuildWall();
      builder.BuildWall();
      builder.BuildWall();
      builder.BuildWall();

      builder.BuildWindows();
      builder.BuildWindows();

      builder.BuildFloor();
      builder.BuildHouseCeiling();

      return builder.GetHouse();
    }
  }
}