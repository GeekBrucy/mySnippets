using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

namespace _01_Basic.Helpers;

public static class KeyVaultConfigGenerator
{
  public static AzureKeyVaultConfigurationOptions ReloadInterval(TimeSpan timeSpan)
  {
    return new AzureKeyVaultConfigurationOptions
    {
      ReloadInterval = timeSpan
    };
  }
}
