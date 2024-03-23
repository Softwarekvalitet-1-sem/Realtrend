using FluentAssertions;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Realtrend.Library;
using Realtrend.Services;
using RealTrend.UnitTests.DataClasses;
using System.Net;

namespace RealTrend.UnitTests
{
    public class Api_unit_tests
    {
        // Mock af HttpClient og test af GetIdFromAddress metode.
        // Vi opretter en mock af HttpClient for at simulere et kald til en ekstern API.
        // Vi opretter en HttpResponseMessage med statuskode OK og en Address som content.
        // Vi opretter en AddressService med vores mock HttpClient og kalder GetIdFromAddress metoden.
        // Vi sammenligner den forventede Id med den faktiske Id.
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
        // Mock af HttpClient og test af GetAddressDetail metode
        // Vi opretter en mock af HttpClient for at simulere et kald til en ekstern API.
        // Vi opretter en HttpResponseMessage med statuskode OK og en Address som content.
        // Vi opretter en AddressDetailService med vores mock HttpClient og kalder GetAddressDetail metoden fra vores service.
        // Vi sammenligner den forventede Address med den faktiske Address.
        // [Theory]
        // [MemberData(nameof(GetAddressDetail))]
        // public async Task GetAddressDetail_Should_Return_Correct_Address_Details(Address expectedAddress)
        // {
        //     // Arrange
        //     var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        //     var response = new HttpResponseMessage
        //     {
        //         StatusCode = HttpStatusCode.OK,
        //         Content = new StringContent(JsonConvert.SerializeObject(expectedAddress))
        //     };

        //     mockHttpMessageHandler.Protected()
        //         .Setup<Task<HttpResponseMessage>>(
        //             "SendAsync",
        //             ItExpr.IsAny<HttpRequestMessage>(),
        //             ItExpr.IsAny<CancellationToken>())
        //         .ReturnsAsync(response);

<<<<<<< HEAD
        //     var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        //     var addressDetailService = new AddressDetailService(httpClient);

        //     // Act
        //     var actualAddress = addressDetailService.GetAddressDetail("");
=======
            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var addressDetailService = new AddressService(httpClient);

            // Act
            var actualAddress = addressDetailService.GetAddressResponseAsync("");
>>>>>>> fd78881 (Models, Mocking & dummy services(Not done))

        //     // Assert
        //     Assert.Equal(JsonConvert.SerializeObject(expectedAddress), JsonConvert.SerializeObject(actualAddress));
        // }

        // public static IEnumerable<object[]> GetAddressDetail()
        // {
        //     yield return new object[]
        //     {
        // new Address
        // {
        //     Id = "66a973e3-a800-4e8d-869a-879621bcf3bc",
        //     Status = 1,
        //     Darstatus = 1,
        //     Vejkode = "123",
        //     Vejnavn = "Seebladsgade",
        //     Adresseringsvejnavn = "Seebladsgade",
        //     Husnr = "1",
        //     Etage = "1",
        //     D�r = "1",
        //     Supplerendebynavn = "Supplerendebynavn",
        //     Postnr = "1234",
        //     Postnrnavn = "Postnrnavn",
        //     Stormodtagerpostnr = "1234",
        //     Stormodtagerpostnrnavn = "Stormodtagerpostnrnavn",
        //     Kommunekode = "123",
        //     Adgangsadresseid = "Adgangsadresseid",
        //     X = 12.34,
        //     Y = 56.78,
        //     Href = "http://example.com",
        //     Betegnelse = "Betegnelse"
        // }
        //     };
        // }

        [Theory]
        [ClassData(typeof(UserAddressTestData))]
        public async Task IsValidAddress_ShouldWorkWithVariousInputs(string address, bool expected)
        {
            var addressService = new AddressService(new HttpClient());
            bool result = await addressService.ValidateAddress(address);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12345", 123.45)]
        public async Task GetAssessment_ValidPropertyId_ReturnsAssessment(string propertyId, double expectedAssessment)
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedAssessment.ToString())
            };

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var basicValueSpecificationService = new BasicValueSpecificationService(httpClient);

            // Act
            var actualAssessment = await basicValueSpecificationService.GetAssessment(propertyId);

            // Assert
            actualAssessment.Should().Be(expectedAssessment);
        }
    }
}
