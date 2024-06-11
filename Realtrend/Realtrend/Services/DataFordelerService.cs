using Realtrend.Library.Interfaces;
using Realtrend.Library.Models.API.DataFordeler;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Realtrend.Services
{
    public class DataFordelerService : IDataFordelerService
    {
        private readonly HttpClient _httpClient;

        public DataFordelerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DataFordelerAddresse>> GetDataFordelerAddressAsync(string addressId)
        {
            var encodedId = System.Net.WebUtility.UrlEncode(addressId);
            var endpoint = $"https://services.datafordeler.dk/DAR/DAR/2.0.0/rest/adresse?id={encodedId}&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var addresses = await response.Content.ReadFromJsonAsync<IEnumerable<DataFordelerAddresse>>();
                return addresses ?? Enumerable.Empty<DataFordelerAddresse>();
            }
            else
            {
                throw new HttpRequestException($"API request failed with status code: {response.StatusCode}.");
            }
        }

        public async Task<IEnumerable<DatafordelerGrundData>> GetDataFordelerGrundDataAsync(string jordStykke)
        {
            var endpoint = $"https://services.datafordeler.dk/BBR/BBRPublic/1/rest/grund?jordstykke={jordStykke}&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var grunde = await response.Content.ReadFromJsonAsync<IEnumerable<DatafordelerGrundData>>();
                return grunde ?? Enumerable.Empty<DatafordelerGrundData>();
            }
            else
            {
                throw new HttpRequestException($"API request failed with status code: {response.StatusCode}.");
            }
        }
    }
}
