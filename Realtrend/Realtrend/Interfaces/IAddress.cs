using Realtrend.Models;

namespace Realtrend.Interfaces
{
    public interface IAddress
    {
        Task<string> GetIdFromAddress(string address);
        Task<bool> ValidateAddress(string address);
        Task<IEnumerable<Address>> GetAddressResponseAsync(string address);
    }
}
