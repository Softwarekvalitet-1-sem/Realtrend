using Realtrend.Library.Models.API.DataForsyning;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realtrend.Library.Interfaces
{
    public interface IDataForsyningService
    {
        Task<DataForsyningAddresse> GetDataForsyningAddressAsync(string address);
    }
}