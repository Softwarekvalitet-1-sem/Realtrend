using Realtrend.Models;

namespace Realtrend.Interfaces
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
