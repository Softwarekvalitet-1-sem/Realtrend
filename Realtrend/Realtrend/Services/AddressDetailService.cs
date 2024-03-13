using Realtrend.Interfaces;

namespace Realtrend.Services
{
    public class AddressDetailService : IAddressDetail
    {
        private readonly HttpClient _httpClient;

        public AddressDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetAddressDetail(string AddressId)
        {
            return "";
        }

    }
}
