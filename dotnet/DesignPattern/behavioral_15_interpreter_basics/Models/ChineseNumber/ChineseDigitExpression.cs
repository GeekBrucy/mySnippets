using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using behavioral_15_interpreter_basics.Interfaces;
using behavioral_15_interpreter_basics.Models.Common;

namespace behavioral_15_interpreter_basics.Models.ChineseNumber
{
    public class ChineseDigitExpression : INumberExpression
    {
        private static readonly Dictionary<string, int> _numbers = new()
        {
            { "零", 0 }, { "一", 1 }, { "二", 2 }, { "三", 3 },
            { "四", 4 }, { "五", 5 }, { "六", 6 }, { "七", 7 },
            { "八", 8 }, { "九", 9 }
        };

        public void Interpret(NumberContext context)
        {
            if (string.IsNullOrEmpty(context.Input)) return;

            string word = context.Input[0].ToString();
            context.Input = context.Input[1..];

            if (_numbers.TryGetValue(word, out int value))
            {
                context.Current = context.Current * 10 + value;
            }
        }

    }
}