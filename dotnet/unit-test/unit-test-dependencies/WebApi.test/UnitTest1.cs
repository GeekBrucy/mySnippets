using FluentAssertions;
using Xunit.Abstractions;

namespace WebApi.test;

public class UnitTest1 : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(DatabaseFixture fixture, ITestOutputHelper testOutputHelper)
    {
        _fixture = fixture;
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        // Act
        var test = _fixture.Connstr;
        _testOutputHelper.WriteLine(new string('*', 30));
        _testOutputHelper.WriteLine("Test 1: Class Fixture");
        _testOutputHelper.WriteLine(new string('*', 30));
        // Assert
        test.Should().Be("From DatabaseFixture");
    }
}
