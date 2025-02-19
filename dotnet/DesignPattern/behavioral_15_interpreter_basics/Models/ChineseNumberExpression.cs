// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using behavioral_15_interpreter_basics.Interfaces;
// using behavioral_15_interpreter_basics.Models.Abstracts;

// namespace behavioral_15_interpreter_basics.Models
// {
//     public class ChineseNumberExpression : INumberExpression<long>
//     {
//         public long Interpret(NumberContext<long> context)
//         {
//             long result = 0;
//             long current = 0;
//             List<long> multipliers = new List<long>();
//             var stringLength = context.Input.Length;
//             foreach (var word in context.Input.Select(c => c.ToString()))
//             {
//                 if (ChineseNumberDictionary.NumberWords.TryGetValue(word, out int value))
//                 {
//                     current = value;
//                 }
//                 else if (ChineseNumberDictionary.Multipliers.TryGetValue(word, out long multiplier))
//                 {
//                     // if the multiplier is at the end of the input string
//                     // and it is biggest multiplier
//                     // then multiply the result and the multiplier
//                     if (
//                         context.Input.IndexOf(word) == stringLength - 1
//                         && multipliers.Any(m => m > multiplier) == false
//                     )
//                     {
//                         result = result * multiplier;
//                     }
//                     else
//                     {
//                         current = current == 0 ? 1 : current;
//                         result += current * multiplier;
//                         current = 0;
//                     }
//                     multipliers.Add(multiplier);
//                 }
//             }

//             return current + result;
//         }
//     }
// }