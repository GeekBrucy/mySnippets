using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_DDD_Feature_Demo.Models;

public record Geo
{
  public double Latitude { get; init; }
  public double Longitude { get; init; }

  public Geo(double latitude, double longitude)
  {
    if (latitude < -90 || latitude > 90)
    {
      throw new ArgumentException("Invalid Latitude");
    }

    if (longitude < -180 || longitude > 180)
    {
      throw new ArgumentException("Invalid Longitude");
    }

    Latitude = latitude;
    Longitude = longitude;
  }
}
