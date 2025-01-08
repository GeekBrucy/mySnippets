using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_v05_webapp_security.DTO;

public class WeatherForecastDTO
{
  public DateOnly Date { get; set; }

  public int TemperatureC { get; set; }

  public int TemperatureF { get; set; }

  public string? Summary { get; set; }
}
