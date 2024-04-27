using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPIConfig.Interfaces;
using DemoWebAPIConfig.Providers.ConfigFromDb;

namespace DemoWebAPIConfig.Extensions;

public static class ConfigurationManagerExtensions
{
  public static ConfigurationManager AddAppSettingsConfiguration(
    this ConfigurationManager manager,
    IGetAppSettingsFromDb appSettingsGetter
  )
  {
    IConfigurationBuilder configBuilder = manager;
    configBuilder.Add(new AppSettingsSource(appSettingsGetter));
    return manager;
  }
}
