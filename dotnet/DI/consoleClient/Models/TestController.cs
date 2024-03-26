using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Interfaces;

namespace consoleClient.Models;

public class TestController
{
  private readonly ILog _log;
  private readonly IStorage _storage;

  public TestController(ILog log, IStorage storage)
  {
    _log = log;
    _storage = storage;
  }

  public void Run()
  {
    _log.Log("Start uploading");
    _storage.Save("test conent", "1.txt");
    _log.Log("Finish uploading");
  }
}
