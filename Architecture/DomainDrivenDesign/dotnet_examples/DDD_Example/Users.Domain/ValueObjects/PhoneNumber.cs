using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Domain.ValueObjects;

public record PhoneNumber(int RegionCode, string Number);