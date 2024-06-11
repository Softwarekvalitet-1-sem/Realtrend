using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTrend.Tests.TestData
{
    public class DataFordelerAddressesWithJordstykke : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
            "some-id",
            new List<DataFordelerAddresse>
            {
                new DataFordelerAddresse { Husnummer = new HusnummerData { Jordstykke = "jordstykke1" } },
                new DataFordelerAddresse { Husnummer = new HusnummerData { Jordstykke = "jordstykke2" } }
            }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
