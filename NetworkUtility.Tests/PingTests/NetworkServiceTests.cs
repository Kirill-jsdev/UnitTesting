using NetworkUtility.Ping;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using NetworkUtility.DNS;
using FakeItEasy;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;
        private readonly IDNS _dns; 

        public NetworkServiceTests()
        {
            //Fake interface
            _dns = A.Fake<IDNS>();


            //SUT - System Under Test
            _networkService = new NetworkService(_dns);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnsSuccessMessage()
        {
            //Arrange
            //Faking the call of SendDNS method to return true
            A.CallTo(() => _dns.SendDNS()).Returns(true);

            var result = _networkService.SendPing();
            // Assert
            result.Should().Be("SUCCESS: Ping sent");
            result.Should().NotBeNullOrEmpty();
            result.Should().Contain("SUCCESS", Exactly.Once());
        }

        [Theory]
        [InlineData(2, 3, 5)]
        public void NetworkService_PingTimeout_ReturnsCorrectSum(int a, int b, int expectedSum)
        {

            var result = _networkService.PingTimeout(a, b);
            // Assert
            result.Should().Be(expectedSum);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnsRecentDateTime()
        {

            var result = _networkService.LastPingDate();
            // Assert
            result.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsCorrectPingOptions()
        {
            //Arrange
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 128
            };

            var result = _networkService.GetPingOptions();
            // Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.DontFragment.Should().BeTrue();
            result.Ttl.Should().Be(128);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnsCorrectPingOptionsList()
        {
            //Arrange
            var expected = new List<PingOptions>
            {
                new PingOptions
                {
                    DontFragment = true,
                    Ttl = 128
                },
                new PingOptions
                {
                    DontFragment = false,
                    Ttl = 64
                }
            };
            var result = _networkService.MostRecentPings();
            // Assert
            result.Should().BeOfType<List<PingOptions>>();
            result.Should().BeEquivalentTo(expected);
            result.Should().HaveCount(2);
            result.First().DontFragment.Should().BeTrue();
            result.First().Ttl.Should().Be(128);
            result.Last().DontFragment.Should().BeFalse();
            result.Last().Ttl.Should().Be(64);
        }
    }
}
