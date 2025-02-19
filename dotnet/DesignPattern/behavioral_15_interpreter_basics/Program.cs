using behavioral_15_interpreter_basics.Models.ChineseNumber;

var interpreter = new ChineseNumberInterpreter();

Console.WriteLine(interpreter.Interpret("七十万"));
Console.WriteLine(interpreter.Interpret("十二"));
Console.WriteLine(interpreter.Interpret("一万零二十四"));
Console.WriteLine(interpreter.Interpret("一亿零二十四"));
Console.WriteLine(interpreter.Interpret("三百二十万七千五百二十"));
Console.WriteLine(interpreter.Interpret("一亿二千万"));
Console.WriteLine(interpreter.Interpret("一亿零三十二万七千"));