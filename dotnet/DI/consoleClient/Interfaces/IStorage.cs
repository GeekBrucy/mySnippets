using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consoleClient.Interfaces;

public interface IStorage
{
  public void Save(string content, string name);
}
