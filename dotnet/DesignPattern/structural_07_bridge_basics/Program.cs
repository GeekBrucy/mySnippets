// See https://aka.ms/new-console-template for more information
using structural_07_bridge_basics.Models.Abstracts_Good;
using structural_07_bridge_basics.Models.Concretes_Good;

Console.WriteLine("Hello, World!");

TankPlatformImplementation tankPlatformImplementation = new PCTankImplementation();
T50 t50 = new T50(tankPlatformImplementation);

t50.Run();
t50.Shot();
t50.Turn();