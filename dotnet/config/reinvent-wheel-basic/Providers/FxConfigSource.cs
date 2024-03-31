using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace reinvent_wheel_basic.Providers;

public class FxConfigSource : FileConfigurationSource
{
  public override IConfigurationProvider Build(IConfigurationBuilder builder)
  {
    return new FxConfigProvider(this);
  }
}
