// See https://aka.ms/new-console-template for more information

using structural_09_decorator_basics.Good.Models.Abstracts;
using structural_09_decorator_basics.Good.Models.Concrete;
using structural_09_decorator_basics.Models.Good.Concrete;

Console.WriteLine("Hello, World!");

Tank t50 = new T50();

DecoratorA da = new DecoratorA(t50);
DecoratorB db = new DecoratorB(da);
DecoratorC dc = new DecoratorC(db);

dc.Shot();
dc.Run();