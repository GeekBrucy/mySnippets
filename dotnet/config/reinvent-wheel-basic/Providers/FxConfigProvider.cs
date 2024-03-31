using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Configuration;

namespace reinvent_wheel_basic.Providers;

public class FxConfigProvider : FileConfigurationProvider
{
  public FxConfigProvider(FxConfigSource source) : base(source)
  {
  }

  public override void Load(Stream stream)
  {
    // use parent data
    Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(stream);
    var connectionStringNodes = xmlDoc.SelectNodes("/configuration/connectionStrings/add");
    foreach (XmlNode xmlNode in connectionStringNodes)
    {
      string name = xmlNode.Attributes["name"].Value;
      string connectionString = xmlNode.Attributes["connectionString"].Value;
      Data[$"{name}:connectionString"] = connectionString;

      var attrProviderName = xmlNode.Attributes["providerName"];
      if (attrProviderName != null)
      {
        Data[$"{name}:providerName"] = attrProviderName.Value;
      }
    }

    var appSettingsNodes = xmlDoc.SelectNodes("/configuration/appSettings/add");
    foreach (XmlNode xmlNode in appSettingsNodes)
    {
      string key = xmlNode.Attributes["key"].Value;
      key = key.Replace(".", ":");
      string value = xmlNode.Attributes["value"].Value;
      Data[key] = value;
    }
  }
}
