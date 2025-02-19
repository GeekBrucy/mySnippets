// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using behavioral_15_interpreter_basics.Interfaces;
// using behavioral_15_interpreter_basics.Models.Abstracts;

// namespace behavioral_15_interpreter_basics.Models
// {
//     public class EnglishNumberExpression : INumberExpression<long>
//     {
//         public long Interpret(NumberContext<long> context)
//         {
//             var words = context.Input.ToLower().Replace(" and ", " ").Split(' ');

//             long result = 0;
//             long current = 0;

//             foreach (var word in words)
//             {
//                 if (EnglishNumberDictionary.NumberWords.TryGetValue(word, out int value))
//                 {
//                     current += value;
//                 }
//                 else if (word == "hundred")
//                 {
//                     current *= 100;
//                 }
//                 else if (EnglishNumberDictionary.Multipliers.TryGetValue(word, out long multiplier))
//                 {
//                     result += current * multiplier;
//                     current = 0;
//                 }
//             }

//             return current + result;
//         }
//     }
// }