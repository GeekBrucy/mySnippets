using System.Text;

internal class Program
{
  private static async Task Main(string[] args)
  {
    // await WrongUsage();
    // Console.WriteLine(await DownloadHtmlAsync("https://azure.microsoft.com/en-au", @"./html.txt"));
    // NoAsyncFunc();
    // await SwitchThread();
    // await SwitchThread2();

    /*
    No matter how slow the StayInTheSameThreadAsync is, the thread number will not change, as the async is inside of Main and Main will always use one thread
    */
    // Console.WriteLine($"Thread id before await: {Thread.CurrentThread.ManagedThreadId}");
    // var r = await (StayInTheSameThreadAsync(50000));
    // Console.WriteLine($"r={r}");
    // Console.WriteLine($"Thread id after await: {Thread.CurrentThread.ManagedThreadId}");

    /*
    The Task.Run in ManualSwitchThread will cause switch thread
    */
    // Console.WriteLine($"Thread id before await: {Thread.CurrentThread.ManagedThreadId}");
    // var r = await (ManualSwitchThread(50000));
    // Console.WriteLine($"r={r}");
    // Console.WriteLine($"Thread id after await: {Thread.CurrentThread.ManagedThreadId}");

    // await NoAsyncKeyword(1);
    // CancellationTokenSource cts = new CancellationTokenSource();
    // cts.CancelAfter(5000);
    // await DemoCancellationToken("https://books.toscrape.com/", 100, cts.Token);

    // CancellationTokenSource cts = new CancellationTokenSource();
    // CancellationToken cToken = cts.Token;
    // CancelOnKeyPress("https://books.toscrape.com/", 100, cts.Token);
    // while (Console.ReadLine() != "q") { }
    // Console.WriteLine("------- q is pressed -------");
    // cts.Cancel();

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

  static async Task SwitchThread()
  {
    // get current thread id before await
    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 10000; i++)
    {
      sb.Append("abc");
    }
    await File.WriteAllTextAsync("./test.txt", sb.ToString());
    // get current thread id after await, the thread id may differ
    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
  }

  static async Task SwitchThread2()
  {
    // get current thread id before await
    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    StringBuilder sb = new StringBuilder();
    // reduce the iteration number
    for (int i = 0; i < 10; i++)
    {
      sb.Append("abc");
    }
    await File.WriteAllTextAsync("./test.txt", sb.ToString());
    // get current thread id after await, the thread id will be the same because the write is quick
    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
  }

  static async Task<double> StayInTheSameThreadAsync(int n)
  {
    Console.WriteLine($"StayInTheSameThreadAsync: {Thread.CurrentThread.ManagedThreadId}");
    double result = 0;
    Random random = new Random();
    for (var i = 0; i < n * n; i++)
    {
      result += random.NextDouble();
    }
    return result;
  }

  static async Task<double> ManualSwitchThread(int n)
  {
    // Task.Run will use new thread
    return await Task.Run(() =>
    {
      Console.WriteLine();
      double result = 0;
      Random random = new Random();
      for (var i = 0; i < n * n; i++)
      {
        result += random.NextDouble();
      }
      return result;
    });
  }

  /// <summary>
  /// The function returns task but there is no async
  /// </summary>
  /// <returns></returns>
  static Task<string> NoAsyncKeyword(int num)
  {

    switch (num)
    {
      case 1:
        return File.ReadAllTextAsync("./1.txt");
      case 2:
        return File.ReadAllTextAsync("./2.txt");
      default:
        throw new ArgumentException();
    }
  }

  /// <summary>
  /// If need to wait, try use Task.Delay() 
  /// rather than Tread.Sleep(), because sleep will block thread
  /// </summary>
  /// <returns></returns>
  static async Task UseDelayNoSleep()
  {
    using HttpClient httpClient = new HttpClient();
    string s = await httpClient.GetStringAsync("https://azure.microsoft.com/en-au");
    // Thread.Sleep will freeze the application
    // Thread.Sleep(3000);
    await Task.Delay(3000);
    string s2 = await httpClient.GetStringAsync("https://www.google.com.au");
  }

  /// <summary>
  /// CancellationToken is used to terminate the request
  /// </summary>
  /// <returns></returns>
  static async Task DemoCancellationToken(string url, int n, CancellationToken cancellationToken)
  {
    using HttpClient httpClient = new HttpClient();

    for (var i = 0; i < n; i++)
    {
      var resp = await httpClient.GetAsync(url, cancellationToken);
      string html = await resp.Content.ReadAsStringAsync();
      Console.WriteLine($"{DateTime.Now}: {html.Substring(0, 20)}");
      if (cancellationToken.IsCancellationRequested)
      {
        Console.WriteLine("Request cancelled");
        break;
      }
    }
  }

  static async Task CancelOnKeyPress(string url, int n, CancellationToken cancellationToken)
  {
    using HttpClient httpClient = new HttpClient();

    for (var i = 0; i < n; i++)
    {
      var resp = await httpClient.GetAsync(url, cancellationToken);
      string html = await resp.Content.ReadAsStringAsync();
      Console.WriteLine($"{DateTime.Now}: {html.Substring(0, 20)}");
      if (cancellationToken.IsCancellationRequested)
      {
        Console.WriteLine("Request cancelled");
        break;
      }
    }
  }
}