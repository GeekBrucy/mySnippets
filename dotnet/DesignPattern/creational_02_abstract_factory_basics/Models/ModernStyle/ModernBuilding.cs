using creational_02_abstract_factory_basics.Models.Abstracts;

namespace creational_02_abstract_factory_basics.Models.ModernStyle
{
  public class ModernBuilding : Building
  {
    public override void Build()
    {
      Console.WriteLine("Start building Modern Building");
    }
  }
}