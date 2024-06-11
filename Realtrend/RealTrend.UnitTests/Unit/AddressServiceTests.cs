using FluentAssertions;
using Moq;
using Realtrend.Library.Interfaces;
using Realtrend.Library.Models.API.DataForsyning;
using Realtrend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RealTrend.UnitTests
{
    public class AddressServiceTests
    {
        [Fact]
        public async Task ValidateAddress_ReturnsTrue_WhenAddressIsValid()
        {
            // Arrange
            var mockAddressValidator = new Mock<IAddressValidator>();
            mockAddressValidator.Setup(v => v.ValidateAddress(It.IsAny<string>())).ReturnsAsync(true);

            var service = new AddressService(mockAddressValidator.Object, Mock.Of<IDataForsyningService>(), Mock.Of<IDataFordelerService>());

            // Act
            var result = await service.ValidateAddress("Valid Address");

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetDataForsyningAddressAsync_ReturnsAddress()
        {
            // Arrange
            var expectedAddress = new DataForsyningAddresse { Id = "843148193841903841" };

            var mockDataForsyningService = new Mock<IDataForsyningService>();
            mockDataForsyningService.Setup(s => s.GetDataForsyningAddressAsync(It.IsAny<string>())).ReturnsAsync(expectedAddress);

            var service = new AddressService(Mock.Of<IAddressValidator>(), mockDataForsyningService.Object, Mock.Of<IDataFordelerService>());

            // Act
            var address = await service.GetDataForsyningAddressAsync("some address");

            // Assert
            address.Should().BeEquivalentTo(expectedAddress);
        }

    }
}
