using Realtrend.Interfaces;
using Realtrend.Models;
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

        public async Task<bool> ValidateAddress(string address)
        {
            // Regex pattern: Starts with letters, followed by a space, and ends with numbers
            string pattern = @"^[A-Za-z]+ \d+$";

            // Create a Regex object with the pattern
            Regex regex = new Regex(pattern);

            // Check if the address matches the pattern
            return regex.IsMatch(address);
        }


    }
}
