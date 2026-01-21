using NetworkUtility.Ping;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnsSuccessMessage()
        {
            // Arrange
            var networkService = new NetworkService();
            // Act
            var result = networkService.SendPing();
            // Assert
            result.Should().Be("SUCCESS: Ping sent");
            result.Should().NotBeNullOrEmpty();
            result.Should().Contain("SUCCESS", Exactly.Once());
        }

        [Theory]
        [InlineData(2, 3, 5)]
        public void NetworkService_PingTimeout_ReturnsCorrectSum(int a, int b, int expectedSum)
        {
            // Arrange
            var networkService = new NetworkService();
            // Act
            var result = networkService.PingTimeout(a, b);
            // Assert
            result.Should().Be(expectedSum);
        }

    }
}
