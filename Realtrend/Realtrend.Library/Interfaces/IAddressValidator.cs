using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtrend.Library.Interfaces
{
    public interface IAddressValidator
    {
        Task<bool> ValidateAddress(string address);
    }
}
