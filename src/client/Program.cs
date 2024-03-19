using System.Text;

internal class Program
{
  private static async Task Main(string[] args)
  {
    // await WrongUsage();
    // Console.WriteLine(await DownloadHtmlAsync("https://azure.microsoft.com/en-au", @"./html.txt"));
    // NoAsyncFunc();
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

  static async Task<int> DownloadHtmlAsync(string url, string fileName)
  {
    using HttpClient httpClient = new HttpClient();

    string html = await httpClient.GetStringAsync(url);
    await File.WriteAllTextAsync(fileName, html);

    return html.Length;
  }

  /// <summary>
  /// Demo: if for some reason, the function cannot be
  /// defined as 'async', Wait() and Task.Result can be used
  /// NOTE: it may cause deadlock
  /// </summary>
  static void NoAsyncFunc()
  {
    string fileName = @"./1.txt";
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 10000; i++)
    {
      sb.AppendLine("hello");
    }

    // use Wait() to wait for the process
    File.WriteAllTextAsync(fileName, sb.ToString()).Wait();

    // use Task.Result to get the async result
    string s = File.ReadAllTextAsync(fileName).Result;
    Console.WriteLine(s);
  }

  static void ThreadPoolDemo()
  {
    string fileName = @"./1.txt";
    StringBuilder sb = new StringBuilder();

    // add async to lambda expression
    ThreadPool.QueueUserWorkItem(async (obj) =>
    {
      for (int i = 0; i < 10000; i++)
      {
        sb.AppendLine("hello");
      }
      await File.WriteAllTextAsync(fileName, sb.ToString());

      string s = await File.ReadAllTextAsync(fileName);
    });
  }
}