using Realtrend.Interfaces;
using Realtrend.Models;

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


    }
}
