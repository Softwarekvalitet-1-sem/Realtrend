using Realtrend.Library.Interfaces;
using Realtrend.Library.Models.API.DataForsyning;
using Realtrend.Library.Models.API.DataFordeler;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realtrend.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressValidator _addressValidator;
        private readonly IDataForsyningService _dataForsyningService;
        private readonly IDataFordelerService _dataFordelerService;

        public AddressService(IAddressValidator addressValidator, IDataForsyningService dataForsyningService, IDataFordelerService dataFordelerService)
        {
            _addressValidator = addressValidator;
            _dataForsyningService = dataForsyningService;
            _dataFordelerService = dataFordelerService;
        }

        public async Task<bool> ValidateAddress(string address)
        {
            return await _addressValidator.ValidateAddress(address);
        }

        public async Task<IEnumerable<DataForsyningAddresse>> GetDataForsyningAddressAsync(string address)
        {
            return await _dataForsyningService.GetDataForsyningAddressAsync(address);
        }

        public async Task<IEnumerable<DataFordelerAddresse>> GetDataFordelerAddressAsync(string addressId)
        {
            return await _dataFordelerService.GetDataFordelerAddressAsync(addressId);
        }

        public async Task<IEnumerable<DatafordelerGrundData>> GetDataFordelerGrundDataAsync(string jordStykke)
        {
            return await _dataFordelerService.GetDataFordelerGrundDataAsync(jordStykke);
        }
    }
}
