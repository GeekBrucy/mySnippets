using System.Text.Json;
using DemoWebAPIConfig.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace DemoWebAPIConfig.Providers.ConfigFromDb;

class AppSettingsProvider : ConfigurationProvider, IDisposable
{
  private bool _isDisposed = false;
  private TimeSpan _interval = TimeSpan.FromSeconds(3);
  private ReaderWriterLockSlim lockObj = new ReaderWriterLockSlim();
  private readonly IGetAppSettingsFromDb _appSettingsGetter;
  public AppSettingsProvider(IGetAppSettingsFromDb appSettingsGetter)
  {
    _appSettingsGetter = appSettingsGetter;
    ThreadPool.QueueUserWorkItem(obj =>
    {
      while (!_isDisposed)
      {
        Load();
        Thread.Sleep(_interval);
      }
    });
  }

  private string GetValueForConfig(JsonElement e)
  {
    if (e.ValueKind == JsonValueKind.String)
    {
      //remove the quotes, "ab"-->ab
      return e.GetString();
    }
    else if (e.ValueKind == JsonValueKind.Null
        || e.ValueKind == JsonValueKind.Undefined)
    {
      //remove the quotes, "null"-->null
      return null;
    }
    else
    {
      return e.GetRawText();
    }
  }

  private void LoadJsonElement(string name, JsonElement jsonRoot)
  {
    if (jsonRoot.ValueKind == JsonValueKind.Array)
    {
      int index = 0;
      foreach (var item in jsonRoot.EnumerateArray())
      {
        //https://andrewlock.net/creating-a-custom-iconfigurationprovider-in-asp-net-core-to-parse-yaml/
        //parse as "a:b:0"="hello";"a:b:1"="world"
        string path = name + ConfigurationPath.KeyDelimiter + index;
        LoadJsonElement(path, item);
        index++;
      }
    }
    else if (jsonRoot.ValueKind == JsonValueKind.Object)
    {
      foreach (var jsonObj in jsonRoot.EnumerateObject())
      {
        string pathOfObj = name + ConfigurationPath.KeyDelimiter + jsonObj.Name;
        LoadJsonElement(pathOfObj, jsonObj.Value);
      }
    }
    else
    {
      //if it is not json array or object, parse it as plain string value
      Data[name] = GetValueForConfig(jsonRoot);
    }
  }
  private void TryLoadAsJson(string name, string value)
  {
    var jsonOptions = new JsonDocumentOptions { AllowTrailingCommas = true, CommentHandling = JsonCommentHandling.Skip };
    try
    {
      var jsonRoot = JsonDocument.Parse(value, jsonOptions).RootElement;
      LoadJsonElement(name, jsonRoot);
    }
    catch (JsonException ex)
    {
      //if it is not valid json, parse it as plain string value
      Data[name] = value;
    }
  }

  public override void Load()
  {
    try
    {
      lockObj.EnterWriteLock();
      foreach (var item in _appSettingsGetter.GetSettings())
      {
        if (item.Value.StartsWith("[") && item.Value.EndsWith("]")
          || item.Value.StartsWith("{") && item.Value.EndsWith("}"))
        {
          TryLoadAsJson(item.Key, item.Value);
        }
        else
        {
          Data[item.Key] = item.Value;
        }
      }
    }
    catch
    {
    }
    finally
    {
      lockObj.ExitWriteLock();
    }
  }

  public void Dispose()
  {
    _isDisposed = true;
  }
}