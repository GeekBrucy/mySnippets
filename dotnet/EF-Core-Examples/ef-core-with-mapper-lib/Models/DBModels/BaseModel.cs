using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_with_mapper_lib.Models.DBModels;

public abstract class BaseModel
{
  public bool IsDeleted { get; set; } = false;
}
