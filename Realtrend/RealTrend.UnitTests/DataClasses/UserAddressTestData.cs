using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTrend.UnitTests.DataClasses
{
    public class UserAddressTestData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Testgade 1", true };
            yield return new object[] { "123 Main Street", false };
            // Add more test cases here
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
