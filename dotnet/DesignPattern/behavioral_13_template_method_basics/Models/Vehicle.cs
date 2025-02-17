using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_13_template_method_basics.Models
{
    public abstract class Vehicle
    {
        public abstract void Startup();
        public abstract void Run();
        public abstract void Turn(int degree);
        public abstract void Stop();
        public void Test()
        {
            Startup();
            Run();
            Turn(360);
            Stop();
        }
    }
}