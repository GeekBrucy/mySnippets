using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Interfaces;
using consoleClient.Services;

namespace consoleClient.Demo;

public class DemoWIthoutDI
{
  public static void RunWithTestServiceImpl()
  {
    ITestService service = new TestServiceImpl
    {
      Name = "Somebody"
    };
    service.SayHi();
  }


}
