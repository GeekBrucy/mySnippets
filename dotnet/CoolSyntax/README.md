# Table of content

1. [Global Using](#global-using)
2. [init in Property](#readonly-but-can-be-initialized-property)
3. [Record Type](#record-type)

# Global using

`global using xxx` will make the namespace available globally

Adding a `Usings.cs` to include all possible using can avoid repeated using statement in the project.

## Implicit using

In the C# project, there is a setting `ImplicitUsings` in the `xxx.csproj` file. Set that to `enable`, the compiler will automatically apply using. This only applies to those built in libs.

# Readonly but can be initialized property

`public string Name { get; init;}`

The keyword `init` allows the property to be initialized

# Record Type

`public record Person(int Id, string Name, int Age);`

Behind the scene, it is still a class. By default, it equips with the commonly used functionalities. Like `ToString`, `Equals` etc.

When comparing 2 record types with the same values, the complier will consider they are equal.

```c#
Person p1 = new Person(1, "TTT", 18);
Person p2 = new Person(1, "TTT", 18);
Console.WriteLine(p1 == p2); // return true
```

NOTE: Record type properties are readonly, but can be initialized
