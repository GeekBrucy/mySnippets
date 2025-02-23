using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;
using WebApi.test.Services;
using Xunit;

namespace WebApi.test.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task ProvideCredentials_ChangePasswordAsync_Should_ReturnTrue()
        {
            // Arrange
            var email = "test@test.com";
            var oldPassword = "123456";
            // Act
            FakeUserRepository fakeUserRepository = new FakeUserRepository(email, oldPassword);
            UserService sut = new UserService(fakeUserRepository);
            var actual = await sut.ChangePasswordAsync(email, oldPassword, "654321", CancellationToken.None);

            // Assert
            Assert.True(actual);
            Assert.Equal(1, fakeUserRepository.UpdateAsyncInvokedCounter);
        }
    }
}