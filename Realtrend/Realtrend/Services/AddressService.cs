using Realtrend.Interfaces;
using Realtrend.Library;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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

        public async Task<bool> ValidateAddress(string address)
        {
            string pattern = @"^[A-Za-z]+ \d+$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(address);
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
                    throw new HttpRequestException($"API request failed with status code: {response.StatusCode}.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        //Gets address details from datafordeler - Takes address ID as parameter.
        public async Task<string> GetJordstykkeFromAddressId(string addressId)
        {
            try
            {
                var endpoint = $"https://services.datafordeler.dk/DAR/DAR/2.0.0/rest/adresse?id={addressId}&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    using var jsonDoc = JsonDocument.Parse(jsonResponse);
                    var rootElement = jsonDoc.RootElement;

                    // Navigate to the specific jordstykke value
                    if (rootElement.ValueKind == JsonValueKind.Array && rootElement.GetArrayLength() > 0)
                    {
                        var husnummer = rootElement[0].GetProperty("husnummer");
                        if (husnummer.TryGetProperty("jordstykke", out var jordstykke))
                        {
                            return jordstykke.GetString();
                        }
                    }

                    return null;
                } else
                {
                    throw new HttpRequestException($"API Request failed with status code: {response.StatusCode}");
                }
            } catch(HttpRequestException ex)
            {
                throw ex;
            }
        }

        //Gets BFE Number from datafordeler - Takes Jordstykke as parameter.
        public async Task<string> GetBfeNumberFromJordStykke(string jordStykke)
        {
            try
            {
                var endpoint = $"https://services.datafordeler.dk//BBR/BBRPublic/1/rest/grund?jordstykke={jordStykke}&&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    using var jsonDoc = JsonDocument.Parse(jsonResponse);
                    var rootElement = jsonDoc.RootElement;

                    if (rootElement.ValueKind == JsonValueKind.Array && rootElement.GetArrayLength() > 0)
                    {
                        var bestemtFastEjendom = rootElement[0].GetProperty("bestemtFastEjendom");
                        if (bestemtFastEjendom.TryGetProperty("bfeNummer", out var bfeNumber))
                        {
                            return bfeNumber.ToString();
                        }
                    }
                }

                return null; // Or some other appropriate default value
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
