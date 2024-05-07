using Realtrend.Library.Models.API.DataFordeler;
using Realtrend.Library.Models.API.DataForsyning;

namespace Realtrend.Library.Interfaces
{
    public interface IAddress
    {
        Task<string> GetIdFromAddress(string address);
        Task<bool> ValidateAddress(string address);
        Task<IEnumerable<DataForsyningAddresse>> GetDataForsyningAddressAsync(string address);
        Task<IEnumerable<DataFordelerAddresse>> GetDataFordelerAddressAsync(string addressId);
        Task<IEnumerable<DatafordelerGrundData>> GetDataFordelerGrundDataAsync(string jordStykke);
    }
}
