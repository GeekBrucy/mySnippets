using System.Text;

internal class Program
{
  private static async Task Main(string[] args)
  {
    await WrongUsage();
  }

  static async Task WrongUsage()
  {
    string fileName = @"./1.txt";
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 10000; i++)
    {
      sb.AppendLine("hello");
    }

    // 1. note here there is no await
    File.WriteAllTextAsync(fileName, sb.ToString());

    // 2. Here will throw exception: The process cannot access the file.....
    // because the process is still writing texts to the target file
    string s = File.ReadAllText(fileName);
    Console.WriteLine(s);
  }
}