using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class RareEquipment
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string? Owner { get; set; }
}
