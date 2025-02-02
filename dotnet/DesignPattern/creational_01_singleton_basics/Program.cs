// See https://aka.ms/new-console-template for more information
using creational_01_singleton_basics.Models;

SimpleSingleton s1 = SimpleSingleton.Instance;
SimpleSingleton s2 = SimpleSingleton.Instance;
Console.WriteLine(new string('@', 50));
Console.WriteLine(Object.ReferenceEquals(s1, s2) == true); // should return true
Console.WriteLine(new string('@', 50));