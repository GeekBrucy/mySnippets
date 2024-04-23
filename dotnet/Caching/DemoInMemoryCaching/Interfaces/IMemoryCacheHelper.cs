using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace DemoInMemoryCaching.Interfaces;

/// <summary>
/// /// Source: https://github.com/yangzhongke/NETBookMaterials/blob/main/%E7%AC%AC%E4%B8%83%E7%AB%A0/%E5%86%85%E5%AD%98%E7%BC%93%E5%AD%98/MemoryCacheHelper.cs
/// </summary>
public interface IMemoryCacheHelper
{
  TResult? GetOrCreate<TResult>(string cacheKey, Func<ICacheEntry, TResult?> valueFactory, int expireSeconds);

  Task<TResult?> GetOrCreateAsync<TResult>(string cacheKey, Func<ICacheEntry, Task<TResult?>> valueFactory, int expireSeconds);

  void Remove(string cacheKey);
}
