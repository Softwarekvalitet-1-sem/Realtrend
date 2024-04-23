using Realtrend.Library.Models;

namespace Realtrend.Library.Interfaces
{
    public interface IAddress
    {
        Task<string> GetIdFromAddress(string address);
        Task<bool> ValidateAddress(string address);
        Task<IEnumerable<Address>> GetAddressResponseAsync(string address);
        Task<string> GetJordstykkeFromAddressId(string addressId);
        Task<string> GetBfeNumberFromJordStykke(string jordStykke);
    }
}
