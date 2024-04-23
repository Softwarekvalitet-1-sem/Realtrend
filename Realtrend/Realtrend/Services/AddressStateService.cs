using Realtrend.Library.Models;

namespace Realtrend.Services
{
    public class AddressStateService
    {
        public UserAddress CurrentAddress { get; set; }

        public void SetCurrentAddress(UserAddress address)
        {
            CurrentAddress = address;
        }

        public UserAddress GetCurrentAddress()
        {
            return CurrentAddress;
        }
    }
}
