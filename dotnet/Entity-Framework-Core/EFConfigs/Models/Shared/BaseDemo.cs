using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Data;
using EFConfigs.Interfaces;

namespace EFConfigs.Models.Shared;

public abstract class BaseDemo : IDemo
{
  protected readonly MyDbContext _ctx;

  public BaseDemo()
  {
    _ctx = new MyDbContext();
  }

  public void Dispose()
  {
    _ctx.Dispose();
  }

  public virtual void Run()
  {
    return;
  }

  public virtual Task RunAsync()
  {
    return Task.CompletedTask;
  }
}
