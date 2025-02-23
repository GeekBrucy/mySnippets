# Testing in .NET

https://learn.microsoft.com/en-us/dotnet/core/testing/

# Frameworks

https://learn.microsoft.com/en-us/dotnet/core/testing/#testing-tools

- MSTest
- xUnit (Recommended)
- NUnit

# Useful tools/packages

- Moq: Github https://github.com/devlooped/moq, Nuget: https://www.nuget.org/packages/Moq/
- FluentAssertions
- FakeItEasy
- AutoFixture + AutoFakeItEasy (Packages: AutoFixture.AutoFakeItEasy, AutoFixture.Xunit2)

# Stryker: Mutation Test
https://stryker-mutator.io/docs/stryker-net/getting-started/

# Integration Testing
- WireMock.Net package

```c#
var mockServerCrm = WireMockServer.Start();

mockServerCrm.Given(Request.Create().WithPath("/add").UsingGet().WithParam("i", "1").WithParam("j", "2"))
  .RespondWith(Response.Create().WithStatusCode(200).WithBody("3"));

Console.WriteLine(mockServerCrm.Url);
```