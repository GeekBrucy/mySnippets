// See https://aka.ms/new-console-template for more information
using creational_04_factory_method.Models.Abstracts;

Console.WriteLine("Hello, World!");

var factory = new ToyotaCarFactory();
var car = factory.CreateCar();

Console.WriteLine($"car type: {car.GetType().Name}");