using Realtrend.Interfaces;
using Realtrend.Models;
using System.Net;
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
            return "";

        }

        //Gets address from dataforsyningen - Takes address as parameter.
        public async Task<IEnumerable<Address>> GetAddressResponseAsync(string address)
        {
            try
            {
                var encodedAddress = System.Net.WebUtility.UrlEncode(address);
                var endpoint = $"https://api.dataforsyningen.dk/adresser?q={encodedAddress}&struktur=mini";
                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var addresses = await response.Content.ReadFromJsonAsync<IEnumerable<Address>>();
                    return addresses ?? Enumerable.Empty<Address>();
                }
                else
                {
                    throw new HttpRequestException($"API request failed with status code {response.StatusCode}.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        //Gets address details from datafordeler - Takes address ID as parameter.
        
        //Gets BFE Number from datafordeler

        public async Task<bool> ValidateAddress(string address)
        {
            string pattern = @"^[A-Za-z]+ \d+$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(address);
        }


    }
}
