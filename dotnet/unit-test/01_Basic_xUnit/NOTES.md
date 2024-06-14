# doc

https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test

# Commands to create the project

```bash
dotnet new sln -o {whatever name you want}
cd {whatever name you want}
dotnet new classlib -o PrimeService
ren .\PrimeService\Class1.cs PrimeService.cs
dotnet sln add ./PrimeService/PrimeService.csproj
dotnet new xunit -o PrimeService.Tests
dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
```
