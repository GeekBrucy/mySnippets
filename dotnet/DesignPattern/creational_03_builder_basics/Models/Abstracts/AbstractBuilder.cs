using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creational_03_builder_basics.Models.Abstracts
{
  public abstract class AbstractBuilder
  {
    public abstract void BuildDoor();
    public abstract void BuildWall();
    public abstract void BuildWindows();
    public abstract void BuildFloor();
    public abstract void BuildHouseCeiling();

    public abstract AbstractHouse GetHouse();
  }
}