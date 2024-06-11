using FluentAssertions;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Realtrend.Library.Interfaces;
using Realtrend.Library.Models.API.DataForsyning;
using Realtrend.Services;
using RealTrend.UnitTests.DataClasses;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace RealTrend.UnitTests.Unit
{
    public class ApiUnitTests
    {
        // Mock HttpClient and test GetIdFromAddress method.
        // We create a mock HttpClient to simulate a call to an external API.
        // We create a HttpResponseMessage with status code OK and an Address as content.
        // We create an AddressService with our mock HttpClient and call the GetIdFromAddress method.
        // We compare the expected Id with the actual Id.
        [Theory]
        [InlineData("Seebladsgade 1", "66a973e3-a800-4e8d-869a-879621bcf3bc")]
        public async Task GetIdFromAddress_ValidAddress_ReturnsCorrectId(string address, string expectedId)
        {
            // Arrange: Set up the mock HttpMessageHandler to simulate the API response.
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new List<DataForsyningAddresse> { new DataForsyningAddresse { Id = expectedId } })
            };

            // Configure the mock handler to return the response when SendAsync is called with any HttpRequestMessage.
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);

            // Create the DataForsyningService with the mocked HttpClient.
            var dataForsyningService = new DataForsyningService(httpClient);

            var mockAddressValidator = new Mock<IAddressValidator>();
            var mockDataFordelerService = new Mock<IDataFordelerService>();

            // Create the AddressService, injecting the mock dependencies.
            var addressService = new AddressService(mockAddressValidator.Object, dataForsyningService, mockDataFordelerService.Object);

            // Act: Call the GetDataForsyningAddressAsync method with the test address.
            var dataForsyningAddress = await addressService.GetDataForsyningAddressAsync(address);

            // Assert: Verify that the Id of the returned address matches the expected Id.
            dataForsyningAddress.Should().NotBeNull();
            dataForsyningAddress.Id.Should().Be(expectedId);
        }

        [Theory]
        [ClassData(typeof(AddressTestData))]
        public async Task IsValidAddress_ShouldWorkWithDifferentInputs(string address, bool expected)
        {
            var mockAddressValidator = new Mock<IAddressValidator>();
            mockAddressValidator.Setup(v => v.ValidateAddress(It.IsAny<string>())).ReturnsAsync(expected);

            var mockDataForsyningService = new Mock<IDataForsyningService>();
            var mockDataFordelerService = new Mock<IDataFordelerService>();

            var addressService = new AddressService(mockAddressValidator.Object, mockDataForsyningService.Object, mockDataFordelerService.Object);

            // Act
            var result = await addressService.ValidateAddress(address);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("12345", 123.45)]
        public async Task GetAssessment_ValidPropertyId_ReturnsAssessmentInline(string propertyId, double expectedAssessment)
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
            var actualAssessment = basicValueSpecificationService.GetAssessment(propertyId);

            // Assert
            actualAssessment.Should().Be(expectedAssessment);
        }

        public static IEnumerable<object[]> MemberData()
        {
            yield return new object[] { "12345", 123.45 };
        }

        [Theory]
        [MemberData(nameof(MemberData))]
        public async Task GetAssessment_ValidPropertyId_ReturnsAssessmentMember(string propertyId, double expectedAssessment)
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
            var actualAssessment = basicValueSpecificationService.GetAssessment(propertyId);

            // Assert
            actualAssessment.Should().Be(expectedAssessment);
        }
    }
}
