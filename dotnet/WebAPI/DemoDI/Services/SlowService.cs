using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDI.Services;

public class SlowService
{
  private string[] _files;
  public SlowService()
  {
    _files = Directory.GetFiles("I:/Program Files", "*.pdf", SearchOption.AllDirectories);
  }

  public int Count
  {
    get
    {
      return _files.Length;
    }
  }
}
