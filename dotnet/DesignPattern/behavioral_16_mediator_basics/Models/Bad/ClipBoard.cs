using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_16_mediator_basics.Models.Bad
{
    public class ClipBoard
    {
        public void SetData(string txt)
        {
            Console.WriteLine($"Set string {txt}");
        }
    }
}