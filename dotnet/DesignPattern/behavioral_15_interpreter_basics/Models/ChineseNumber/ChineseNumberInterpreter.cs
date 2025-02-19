using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using behavioral_15_interpreter_basics.Interfaces;
using behavioral_15_interpreter_basics.Models.Common;

namespace behavioral_15_interpreter_basics.Models.ChineseNumber
{
    public class ChineseNumberInterpreter
    {
        private readonly List<INumberExpression> _expressions;

        public ChineseNumberInterpreter()
        {
            _expressions = new List<INumberExpression>
            {
                new ChineseDigitExpression(),  // 个位数字
                new ChineseMultiplierExpression("十", 10),
                new ChineseMultiplierExpression("百", 100),
                new ChineseMultiplierExpression("千", 1000),
                new ChineseLargeMultiplierExpression("万", 10_000),
                new ChineseLargeMultiplierExpression("亿", 100_000_000)
            };
        }

        public long Interpret(string input)
        {
            NumberContext context = new NumberContext(input);

            while (!string.IsNullOrEmpty(context.Input))
            {
                foreach (var expression in _expressions)
                {
                    expression.Interpret(context);
                }
            }

            return context.Output + context.SectionResult + context.Current;
        }
    }
}