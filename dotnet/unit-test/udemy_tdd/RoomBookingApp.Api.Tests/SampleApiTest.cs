using Microsoft.Extensions.Logging;
using Moq;
using RoomBookingApp.Api.Controllers;
using Shouldly;

namespace RoomBookingApp.Api.Tests;

public class SampleApiTest
{
    [Fact]
    public void Should_Return_Forecast_Results()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<WeatherForecastController>>();
        var controller = new WeatherForecastController(loggerMock.Object);

        // Act
        var result = controller.Get();

        // Assert
        result.Count().ShouldBeGreaterThan(1);
        result.ShouldNotBeNull();
    }
}
