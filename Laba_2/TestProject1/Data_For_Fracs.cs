using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
        internal class MyFrac_TestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 1, 2, 3, -3 };
                yield return new object[] { -42, -6, -10,34 };
                yield return new object[] { -2, 2, 0,3 };
                yield return new object[] { 0, 0, 23,1};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    
}
