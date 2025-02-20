// See https://aka.ms/new-console-template for more information
using behavioral_17_iterator_basics.Models;

var books = new BookCollection();
books.AddBook("Design Patterns");
books.AddBook("Clean Code");
books.AddBook("Refactoring");

var iterator = books.GetIterator();
while (iterator.HasNext())
{
  Console.WriteLine(iterator.Next());
}


var numbers = new NumberCollection();
numbers.AddNumber(1);
numbers.AddNumber(2);
numbers.AddNumber(3);

foreach (var number in numbers)
{
  Console.WriteLine(number);
}