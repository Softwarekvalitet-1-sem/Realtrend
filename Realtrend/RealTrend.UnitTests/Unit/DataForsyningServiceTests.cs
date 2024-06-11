using FluentAssertions;
using Moq;
using Moq.Protected;
using Realtrend.Library.Interfaces;
using Realtrend.Library.Models.API.DataForsyning;
using Realtrend.Services;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace RealTrend.UnitTests
{
    public class DataForsyningServiceTests
    {
        [Fact]
        public async Task GetDataForsyningAddressAsync_ReturnsAddress_WhenApiReturnsSuccess()
        {
            // Arrange

            //Opret en mock httpMessageHandler
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            //Opret et HttpResponse objekt, som indeholder en liste af én DataForsyningAddresse med et random id
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new List<DataForsyningAddresse> { new DataForsyningAddresse { Id = "35135183" } })
            };

            //Send responset via mockHttpMessageHandler
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);

            //Instanciér en ny DataForsyningService med den mockede httpClient
            var service = new DataForsyningService(httpClient);

            // Act
            //Kald 
            var address = await service.GetDataForsyningAddressAsync("Seebladsgade 1");

            // Assert
            address.Should().NotBeNull();
            address.Id.Should().Be("35135183");
        }

        [Fact]
        public async Task GetDataForsyningAddressAsync_ThrowsException_WhenApiReturnsFailure()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var service = new DataForsyningService(httpClient);

            // Act
            Func<Task> act = async () => await service.GetDataForsyningAddressAsync("some address");

            // Assert
            await act.Should().ThrowAsync<HttpRequestException>();
        }
    }
}
