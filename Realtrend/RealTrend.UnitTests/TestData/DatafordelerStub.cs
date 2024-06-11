using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTrend.UnitTests.TestData
{
    public class DatafordelerStub : IEnumerable<object[]>
    {
        public IEnumerable<string> GetAddressDetail(string AddressId)
        {
            return new List<string>();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private readonly HttpClient _httpClient;

        public DatafordelerStub(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}

