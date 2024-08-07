using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using _02_NetworkUtility.DNS;

namespace _02_NetworkUtility.Ping;

public class NetworkService
{
  private readonly IDNS _dnsService;
  public NetworkService(IDNS dnsService)
  {
    _dnsService = dnsService;
  }
  public string SendPing()
  {
    var dnsSuccess = _dnsService.SendDNS();
    if (dnsSuccess)
    {
      return "Success: Ping Sent!";
    }
    else
    {
      return "Failed: Ping not sent!";
    }
  }

  public int PingTimeout(int a, int b)
  {
    return a + b;
  }

  public DateTime LastPingDate()
  {
    return DateTime.Now;
  }

  public PingOptions GetPingOptions()
  {
    return new PingOptions
    {
      DontFragment = true,
      Ttl = 1
    };
  }

  public IEnumerable<PingOptions> MostRecentPings()
  {
    IEnumerable<PingOptions> pingOptions = new[]
    {
      new PingOptions
      {
        DontFragment = true,
        Ttl = 1
      },
      new PingOptions
      {
        DontFragment = false,
        Ttl = 2
      },
      new PingOptions
      {
        DontFragment = true,
        Ttl = 3
      },
      new PingOptions
      {
        DontFragment = false,
        Ttl = 4
      },
      new PingOptions
      {
        DontFragment = true,
        Ttl = 5
      }
    };

    return pingOptions;
  }
}
