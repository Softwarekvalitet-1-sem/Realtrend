using Realtrend.Library.Interfaces;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Realtrend.Services
{
    public class AddressValidator : IAddressValidator
    {
        public Task<bool> ValidateAddress(string address)
        {
            string pattern = @"^[A-Za-z]+ \d+$";
            Regex regex = new Regex(pattern);
            return Task.FromResult(regex.IsMatch(address));
        }
    }
}
