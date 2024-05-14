using Realtrend.Library.Models.API.DataForsyning;
using Realtrend.Library.Models.API.DataFordeler;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realtrend.Library.Interfaces
{
    public interface IAddressService
    {
        Task<bool> ValidateAddress(string address);
        Task<IEnumerable<DataForsyningAddresse>> GetDataForsyningAddressAsync(string address);
        Task<IEnumerable<DataFordelerAddresse>> GetDataFordelerAddressAsync(string addressId);
        Task<IEnumerable<DatafordelerGrundData>> GetDataFordelerGrundDataAsync(string jordStykke);
    }
}
