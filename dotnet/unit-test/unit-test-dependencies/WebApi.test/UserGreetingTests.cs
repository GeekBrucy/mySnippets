using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using WebApi.Helpers;
using WebApi.Services;
using Xunit;

namespace WebApi.test
{
    public class UserGreetingTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();

            mockUserService.Setup(service => service.GetUserName(1)).Returns("Test");

            var greeting = new UserGreeting(mockUserService.Object);

            // Act
            var result = greeting.GetGreeting(1);

            // Assert
            Assert.Equal("Hello, Test", result);
        }
    }
}