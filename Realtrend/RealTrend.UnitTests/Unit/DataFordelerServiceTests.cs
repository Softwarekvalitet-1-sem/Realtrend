using FluentAssertions;
using Moq;
using Moq.Protected;
using Realtrend.Library.Models.API.DataFordeler;
using Realtrend.Services;
using RealTrend.Tests.TestData;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class DataFordelerServiceTests
{
    [Theory]
    [InlineData("69420", "awesomejordstykke")]
    public async Task GetDataFordelerAddressAsync_ReturnsAddress_WithJordstykke(string addressId, string expectedJordstykke)
    {
        // Arrange
        var expectedAddress = new DataFordelerAddresse
        {
            Husnummer = new HusnummerData { Jordstykke = expectedJordstykke }
        };
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = JsonContent.Create(new List<DataFordelerAddresse> { expectedAddress })
        };

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var service = new DataFordelerService(httpClient);

        // Act
        var result = await service.GetDataFordelerAddressAsync(addressId);

        // Assert
        result.Should().NotBeNull();
        result.Should().ContainSingle();
        result.First().Husnummer.Jordstykke.Should().Be(expectedJordstykke);
    }

    [Theory]
    [ClassData(typeof(DataFordelerAddressesWithJordstykke))]
    public async Task GetDataFordelerAddressAsync_ReturnsAddresses_WithJordstykke(string addressId, List<DataFordelerAddresse> expectedAddresses)
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = JsonContent.Create(expectedAddresses)
        };

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var service = new DataFordelerService(httpClient);

        // Act
        var result = await service.GetDataFordelerAddressAsync(addressId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedAddresses);
        foreach (var address in result)
        {
            address.Husnummer.Jordstykke.Should().NotBeNullOrEmpty();
        }
    }

    [Theory]
    [MemberData(nameof(DataFordelerServiceMemberData.GetData), MemberType = typeof(DataFordelerServiceMemberData))]
    public async Task GetDataFordelerAddressAsync_HandlesVariousResponses(string addressId, List<DataFordelerAddresse> expectedAddresses)
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = JsonContent.Create(expectedAddresses)
        };

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var service = new DataFordelerService(httpClient);

        // Act
        var result = await service.GetDataFordelerAddressAsync(addressId);

        // Assert
        result.Should().BeEquivalentTo(expectedAddresses);

        foreach (var address in result)
        {
            address.Husnummer.Jordstykke.Should().NotBeNullOrEmpty();
        }
    }

    public class DataFordelerServiceMemberData
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { "some-id", new List<DataFordelerAddresse> { new DataFordelerAddresse { Husnummer = new HusnummerData { Jordstykke = "jordstykke1" } } } };
            yield return new object[] { "some-id", new List<DataFordelerAddresse> { new DataFordelerAddresse { Husnummer = new HusnummerData { Jordstykke = "jordstykke2" } } } }; 
            yield return new object[] { "some-id", new List<DataFordelerAddresse>() }; 
        }
    }

}
