using creational_02_abstract_factory_basics.Models.Abstracts;

namespace creational_02_abstract_factory_basics.Models.ModernStyle
{
  public class ModernJungle : Jungle
  {
    public override void Build()
    {
      Console.WriteLine("Start building Modern Jungle");
    }
  }
}