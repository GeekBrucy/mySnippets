using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_hostedservice_export_data_interval.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _02_hostedservice_export_data_interval.Data;

public class MyDbContext : IdentityDbContext
{
  public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
  {
  }
}
