using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTrend.UnitTests.DataClasses
{
    public class ValidationDataClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            return new List<object[]>
            {
                new object[] { "Seebladsgade 1", "66a973e3-a800-4e8d-869a-879621bcf3bc" },
                new object[] { "Seebladsgade 2", "66a973e3-a800-4e8d-869a-879621bcf3bd" },
                new object[] { "Seebladsgade 3", "66a973e3-a800-4e8d-869a-879621bcf3be" },
                new object[] { "Seebladsgade 4", "66a973e3-a800-4e8d-869a-879621bcf3bf" },
                new object[] { "Seebladsgade 5", "66a973e3-a800-4e8d-869a-879621bcf3bg" },
                new object[] { "Seebladsgade", "66a973e3-a800-4e8d-869a-879621bcf3bh" }
            }.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
