using FluentAssertions;
using Realtrend.Services;
using System.Threading.Tasks;
using Xunit;

namespace RealTrend.UnitTests
{
    public class AddressValidatorTests
    {
        [Theory]
        [InlineData("Mainstreet 123", true)]
        [InlineData("123 Main St", false)]
        public async Task ValidateAddress_ShouldValidateCorrectly(string address, bool expectedResult)
        {
            // Arrange
            var validator = new AddressValidator();

            // Act
            var result = await validator.ValidateAddress(address);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
