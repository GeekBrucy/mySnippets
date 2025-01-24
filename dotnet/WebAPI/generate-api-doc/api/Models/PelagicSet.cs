using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.Models;

public class Shot
{
  // a property either with PreviousSet or CurrentSet
  public BaseSet Set { get; set; }
  public int MyProperty { get; set; }
}
[JsonPolymorphic]
[JsonDerivedType(typeof(PreviousSet))]
[JsonDerivedType(typeof(CurrentSet))]
public abstract class BaseSet { }

public class PreviousSet : BaseSet
{
  public string SetTripActivityNumber { get; set; }
  public string SetTripId { get; set; }
}
public partial class CurrentSet : BaseSet
{
  public string BranchlineWeightingRegime { get; set; }
  public long? BranchlineWeight { get; set; }
  public long? LengthOfBranchline { get; set; }
  public long? BranchlineWeightDistanceFromHook { get; set; }
  public string Comments { get; set; }
  public long? DepthFishedMaximum { get; set; }
  public long? DepthFishedMinimum { get; set; }
  public DateTime EndDateTime { get; set; }
  public double? EndPositionLatitude { get; set; }
  public double? EndPositionLongitude { get; set; }
  public long? FishingDepthTemperatureAverage { get; set; }

  public string FishingGround { get; set; }
  public bool? LineShooterUsed { get; set; }
  public long? LineShootingSpeed { get; set; }
  public long? NumberOfHooksBetweenBubbles { get; set; }
  public long? NumberOfHooksSet { get; set; }
  public Object HookType { get; set; }
  public long? HookSize { get; set; }
  public long? NumberOfLightsticksUsed { get; set; }
  public string ResearchDescription { get; set; }
  public long? SeaSurfaceTemperatureAverage { get; set; }
  public DateTime StartDateTime { get; set; }
  public double? StartSetPositionLatitude { get; set; }
  public double? StartSetPositionLongitude { get; set; }
  public long? TotalLengthOfLineShot { get; set; }
  public long? VesselShootingSpeed { get; set; }
}
