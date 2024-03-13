using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Realtrend.Models;
using Realtrend.Services;
using System.Net;

namespace RealTrend.UnitTests
{
    public class Api_unit_tests
    {
        [Theory]
        [InlineData("Seebladsgade 1", "66a973e3-a800-4e8d-869a-879621bcf3bc")]
        public async Task GetIdFromAddress_ValidAddress_ReturnsCorrectId(string address, string expectedId)
        {

            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(new Address { Id = expectedId }))
            };

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var addressService = new AddressService(httpClient);


            // Act
            var actualId = await addressService.GetIdFromAddress(address);

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Theory]
        [MemberData(nameof(GetAddressDetail))]
        public async Task GetAddress_ReturnsCorrectAddress(Address expectedAddress)
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(expectedAddress))
            };

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var addressDetailService = new AddressDetailService(httpClient);

            // Act
            var actualAddress = addressDetailService.GetAddressDetail("");

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedAddress), JsonConvert.SerializeObject(actualAddress));
        }

        public static IEnumerable<object[]> GetAddressDetail()
        {
            yield return new object[]
            {
        new Address
        {
            Id = "66a973e3-a800-4e8d-869a-879621bcf3bc",
            Status = 1,
            Darstatus = 1,
            Vejkode = "123",
            Vejnavn = "Seebladsgade",
            Adresseringsvejnavn = "Seebladsgade",
            Husnr = "1",
            Etage = "1",
            D�r = "1",
            Supplerendebynavn = "Supplerendebynavn",
            Postnr = "1234",
            Postnrnavn = "Postnrnavn",
            Stormodtagerpostnr = "1234",
            Stormodtagerpostnrnavn = "Stormodtagerpostnrnavn",
            Kommunekode = "123",
            Adgangsadresseid = "Adgangsadresseid",
            X = 12.34,
            Y = 56.78,
            Href = "http://example.com",
            Betegnelse = "Betegnelse"
        }
            };
        }



    }
}