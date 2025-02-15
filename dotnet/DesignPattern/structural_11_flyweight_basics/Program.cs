// See https://aka.ms/new-console-template for more information
using structural_11_flyweight_basics.Models.Good;

Character c1 = new Character { C = 'A' };
c1.Font = new Font("Arial", 12, Color.red);

Character c2 = new Character { C = 'B' };
c2.Font = new Font("Arial", 12, Color.red);

Character c3 = new Character { C = 'C' };
c3.Font = new Font("Times New Roman", 14, Color.blue);

Console.WriteLine(c1.Font == c2.Font); // Should print True
Console.WriteLine(c1.Font == c3.Font); // Should print False