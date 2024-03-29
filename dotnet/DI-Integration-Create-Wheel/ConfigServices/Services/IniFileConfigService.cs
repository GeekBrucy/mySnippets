using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigServices.Interfaces;

namespace ConfigServices.Services;

public class IniFileConfigService : IConfigService
{
  public string FilePath { get; set; }
  public string GetValue(string name)
  {
    // this is a dummy way to read ini file
    var kv = File.ReadLines(FilePath)
    .Select(s => s.Split("="))
    .Select(s => new { Name = s[0], Value = s[1] })
    .SingleOrDefault(kv => kv.Name == name);

    if (kv != null) return kv.Value;

    return null;
  }
}
