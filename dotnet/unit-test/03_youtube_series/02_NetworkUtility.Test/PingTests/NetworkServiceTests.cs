using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_NetworkUtility.Ping;
using FluentAssertions;
using Xunit;

namespace _02_NetworkUtility.Test.PingTests;

public class NetworkServiceTests
{
    [Fact]
    public void NetworkService_SendPing_ReturnString()
    {
        // arrange  - variables, classes, mocks
        var pingService = new NetworkService();

        // act
        var result = pingService.SendPing();

        // assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Ping Sent!");
        result.Should().Contain("Success", Exactly.Once());
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
    {
        // arrange
        var pingService = new NetworkService();

        // act
        var actual = pingService.PingTimeout(a, b);
        // assert
        actual.Should().Be(expected);
        actual.Should().BeGreaterThanOrEqualTo(a + b);
        actual.Should().NotBeInRange(-10000, 0);
    }
}
