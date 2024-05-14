using Realtrend.Library.Models;

namespace Realtrend.Services
{
    public class AddressStateService
    {
        public Address CurrentAddress { get; set; }

        public void SetCurrentAddress(Address address)
        {
            CurrentAddress = address;
        }

        public Address GetCurrentAddress()
        {
            return CurrentAddress;
        }
    }
}
