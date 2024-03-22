namespace client.Delegates;

// in c# action is generic delegate
public static class ActionDemo
{
  public static void Run()
  {
    Action a = NormalFunctions.F1;
    a();

    Action<int, string> a1 = NormalFunctions.F4;
    a1(1, "test");

  }
}
