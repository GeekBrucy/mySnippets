using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_15_interpreter_basics.Models
{
    public static class EnglishNumberDictionary
    {
        public static readonly Dictionary<string, int> NumberWords = new()
        {
            { "zero", 0 }, { "one", 1 }, { "two", 2 }, { "three", 3 },
            { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 },
            { "eight", 8 }, { "nine", 9 }, { "ten", 10 }, { "eleven", 11 },
            { "twelve", 12 }, { "thirteen", 13 }, { "fourteen", 14 },
            { "fifteen", 15 }, { "sixteen", 16 }, { "seventeen", 17 },
            { "eighteen", 18 }, { "nineteen", 19 }, { "twenty", 20 },
            { "thirty", 30 }, { "forty", 40 }, { "fifty", 50 }, { "sixty", 60 },
            { "seventy", 70 }, { "eighty", 80 }, { "ninety", 90 }
        };

        public static readonly Dictionary<string, long> Multipliers = new()
        {
            { "hundred", 100 },
            { "thousand", 1_000 },
            { "million", 1_000_000 },
            { "billion", 1_000_000_000 },
            { "trillion", 1_000_000_000_000 }
        };
    }
}