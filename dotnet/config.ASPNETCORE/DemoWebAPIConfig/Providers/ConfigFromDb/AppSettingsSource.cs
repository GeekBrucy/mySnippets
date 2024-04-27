using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPIConfig.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPIConfig.Providers.ConfigFromDb;

public class AppSettingsSource : IConfigurationSource
{
  private readonly IGetAppSettingsFromDb _appSettingsGetter;
  public AppSettingsSource(IGetAppSettingsFromDb appSettingsGetter)
  {
    _appSettingsGetter = appSettingsGetter;
  }

  public IConfigurationProvider Build(IConfigurationBuilder builder)
  {
    return new AppSettingsProvider(_appSettingsGetter);
  }
}
