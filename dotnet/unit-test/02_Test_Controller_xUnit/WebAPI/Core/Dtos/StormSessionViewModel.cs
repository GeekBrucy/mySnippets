using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Dtos;

public record StormSessionViewModel
(
  int Id,
  string Name,
  DateTimeOffset DateCreated,
  int IdeaCount
);
