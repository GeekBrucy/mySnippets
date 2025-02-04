// See https://aka.ms/new-console-template for more information
using creational_02_abstract_factory_basics.Models;
using creational_02_abstract_factory_basics.Models.ModernStyle;

Console.WriteLine("Hello, World!");

var gameManager = new GameManager(new ModernFacilities());
gameManager.BuildGameFacilities();