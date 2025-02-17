using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_13_template_method_basics.Models
{
    public class Toyota : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Toyota Run");
        }

        public override void Startup()
        {
            Console.WriteLine("Toyota Startup");
        }

        public override void Stop()
        {
            Console.WriteLine("Toyota Stop");
        }

        public override void Turn(int degree)
        {
            Console.WriteLine($"Toyota Turn {degree} degree");
        }
    }
}