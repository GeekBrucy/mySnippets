using behavioral_15_interpreter_basics.Models.ChineseNumber;

var interpreter = new ChineseNumberInterpreter();

Console.WriteLine(interpreter.Interpret("七十万")); // 700000
Console.WriteLine(interpreter.Interpret("十二")); // 2
Console.WriteLine(interpreter.Interpret("一万零二十四")); // 10204
Console.WriteLine(interpreter.Interpret("一亿零二十四")); // 100000204
Console.WriteLine(interpreter.Interpret("三百二十万七千五百二十")); //1000250020
Console.WriteLine(interpreter.Interpret("一亿二千万")); //1000020000000
Console.WriteLine(interpreter.Interpret("一亿零三十二万七千")); //1000003027000