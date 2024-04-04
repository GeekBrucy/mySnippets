using System;
using System.Collections.Generic;

namespace EFDemoReverseEngineering;

public partial class TPerson
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string BirthPlace { get; set; } = null!;

    public double? Salary { get; set; }
}
