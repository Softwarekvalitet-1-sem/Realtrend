using Realtrend.Library.Models.API.DataFordeler;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realtrend.Library.Interfaces
{
    public interface IDataFordelerService
    {
        Task<IEnumerable<DataFordelerAddresse>> GetDataFordelerAddressAsync(string addressId);
        Task<IEnumerable<DatafordelerGrundData>> GetDataFordelerGrundDataAsync(string jordStykke);
    }
}
