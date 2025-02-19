using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using behavioral_15_interpreter_basics.Interfaces;
using behavioral_15_interpreter_basics.Models.Common;

namespace behavioral_15_interpreter_basics.Models.ChineseNumber
{
    public class ChineseMultiplierExpression : INumberExpression
    {
        private readonly long _multiplier;
        private readonly string _character;

        public ChineseMultiplierExpression(string character, long multiplier)
        {
            _multiplier = multiplier;
            _character = character;
        }

        public void Interpret(NumberContext context)
        {
            if (string.IsNullOrEmpty(context.Input)) return;
            if (context.Input.StartsWith(_character))
            {
                context.Input = context.Input[1..];
                context.Current = context.Current == 0 ? 1 : context.Current; // "十" should be 10, not 0
                context.Current *= _multiplier;
            }
        }
    }
}