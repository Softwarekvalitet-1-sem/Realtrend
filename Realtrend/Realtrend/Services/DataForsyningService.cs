using Realtrend.Library.Interfaces;
using Realtrend.Library.Models.API.DataForsyning;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Realtrend.Services
{
    public class DataForsyningService : IDataForsyningService
    {
        private readonly HttpClient _httpClient;

        public DataForsyningService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DataForsyningAddresse> GetDataForsyningAddressAsync(string address)
        {
            var encodedAddress = System.Net.WebUtility.UrlEncode(address);
            var endpoint = $"https://api.dataforsyningen.dk/adresser?q={encodedAddress}&struktur=mini";
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var addresses = await response.Content.ReadFromJsonAsync<IEnumerable<DataForsyningAddresse>>();
                DataForsyningAddresse actualAddress = addresses.First();
                return actualAddress;
            }
            else
            {
                throw new HttpRequestException($"API request failed with status code: {response.StatusCode}.");
            }
        }
    }
}
