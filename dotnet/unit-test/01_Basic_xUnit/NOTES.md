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

# Run test (can run the command under the directory that the .sln resides in)

```bash
dotnet test
```

# Knowledge

- [Theory] represents a suite of tests that execute the same code but have different input arguments.
- [InlineData] attribute specifies values for those inputs.
- [Fact] declares a test method that's run by the test runner.
