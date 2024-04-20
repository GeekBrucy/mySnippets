using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models;

public record ProcessInfo(long id, string Name, long WorkingSet);