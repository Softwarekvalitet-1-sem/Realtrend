using Realtrend.Library.Interfaces;
using Realtrend.Library.Models.API.DataFordeler;
using Realtrend.Library.Models.API.DataForsyning;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Realtrend.Services
{
    public class AddressService : IAddress
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetIdFromAddress(string address)
        {
            return "66a973e3-a800-4e8d-869a-879621bcf3bc";

        }

        public async Task<bool> ValidateAddress(string address)
        {
            string pattern = @"^[A-Za-z]+ \d+$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(address);
        }

        //Gets address from dataforsyningen - Takes address as parameter.
        public async Task<IEnumerable<DataForsyningAddresse>> GetDataForsyningAddressAsync(string address)
        {
            try
            {
                var encodedAddress = System.Net.WebUtility.UrlEncode(address);
                var endpoint = $"https://api.dataforsyningen.dk/adresser?q={encodedAddress}&struktur=mini";
                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var addresses = await response.Content.ReadFromJsonAsync<IEnumerable<DataForsyningAddresse>>();
                    return addresses ?? Enumerable.Empty<DataForsyningAddresse>();
                }
                else
                {
                    throw new HttpRequestException($"API request failed with status code: {response.StatusCode}.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        //Gets address details from datafordeler - Takes address ID as parameter.
        public async Task<IEnumerable<DataFordelerAddresse>> GetDataFordelerAddressAsync(string addressId)
        {
            try
            {
                var encodedId = System.Net.WebUtility.UrlEncode(addressId);
                var endpoint = $"https://services.datafordeler.dk/DAR/DAR/2.0.0/rest/adresse?id={encodedId}&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var addresses = await response.Content.ReadFromJsonAsync<IEnumerable<DataFordelerAddresse>>();
                    return addresses ?? Enumerable.Empty<DataFordelerAddresse>();
                }
                else
                {
                    throw new HttpRequestException($"API request failed with status code: {response.StatusCode}.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Error while requesting data: {ex.Message}", ex);
            }
        }

        //Gets BFE Number from datafordeler - Takes Jordstykke as parameter.
        public async Task<IEnumerable<DatafordelerGrundData>> GetDataFordelerGrundDataAsync(string jordStykke)
        {
            try
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
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Error while requesting data: {ex.Message}", ex);
            }
        }
    }
}
