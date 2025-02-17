using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_13_template_method_basics.Models
{
    public class VehicleTestFramework
    {
        public static void DoTest(Vehicle vehicle)
        {
            vehicle.Test();
        }
    }
}