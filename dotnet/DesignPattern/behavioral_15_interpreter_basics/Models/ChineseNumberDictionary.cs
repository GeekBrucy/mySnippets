using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_15_interpreter_basics.Models
{
    public class ChineseNumberDictionary
    {
        public static readonly Dictionary<string, int> NumberWords = new()
        {
            {"零", 0},
            {"一", 1},
            {"二", 2},
            {"三", 3},
            {"四", 4},
            {"五", 5},
            {"六", 6},
            {"七", 7},
            {"八", 8},
            {"九", 9},
        };
        public static readonly Dictionary<string, long> Multipliers = new()
        {
            { "十", 10 },
            { "百", 100 },
            { "千", 1_000 },
            { "万", 10_000 },
            { "亿", 100_000_000 },
        };
    }
}