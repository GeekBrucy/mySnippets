using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using _02_NetworkUtility.Ping;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace _02_NetworkUtility.Test.PingTests;

public class NetworkServiceTests
{
    private readonly NetworkService _networkService;

    public NetworkServiceTests()
    {
        // SUT
        _networkService = new NetworkService();
    }

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

    [Fact]
    public void NetworkService_LastPingDate_ReturnDate()
    {
        // arrange

        // act
        var actual = _networkService.LastPingDate();
        // assert
        actual.Should().BeAfter(1.January(2010));
        actual.Should().BeBefore(1.January(2030));
    }

    [Fact]
    public void NetworkService_GetPingOptions_ReturnObject()
    {
        // arrange
        var expected = new PingOptions
        {
            DontFragment = true,
            Ttl = 1
        };
        // act
        var actual = _networkService.GetPingOptions();
        // assert WARNING: "Be" careful
        // for reference type,use BeEquivalentTo
        actual.Should().BeOfType<PingOptions>();
        actual.Should().BeEquivalentTo(expected);
        actual.Ttl.Should().Be(1);
    }

    [Fact]
    public void NetworkService_MostRecentPings_ReturnIEnumerable()
    {
        // arrange
        IEnumerable<PingOptions> expected = new[]
        {
            new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            }
        };
        // act
        var actual = _networkService.MostRecentPings();
        // assert
        actual.Should().AllBeOfType<PingOptions>();
        actual.Where(x => x.Ttl == 1).Select(x => x.DontFragment)
        .Should().Equal
        (
            expected.Where(x => x.Ttl == 1).Select(x => x.DontFragment)
        );
        actual.Should().Contain(x => x.DontFragment == true);
    }
}
