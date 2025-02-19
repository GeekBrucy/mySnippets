using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_15_interpreter_basics.Models.Common
{
    public class NumberContext
    {
        public string Input { get; set; }
        public long Output { get; set; } = 0;
        public long Current { get; set; } = 0;
        public long SectionResult { get; set; } = 0; // Handles "万", "亿"

        public NumberContext(string input)
        {
            Input = input;
        }
    }
}