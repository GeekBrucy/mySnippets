namespace creational_01_singleton_basics.Models
{
  public class SimpleSingleton
  {
    private static SimpleSingleton instance;
    private SimpleSingleton() { }

    public static SimpleSingleton Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new SimpleSingleton();
        }

        return instance;
      }
    }
  }
}