// See https://aka.ms/new-console-template for more information
using creational_03_builder_basics.Models;
using creational_03_builder_basics.Models.Houses;

Console.WriteLine("Hello, World!");

var house = HouseManager.CreateHouse(new FarmHouseBuilder());

