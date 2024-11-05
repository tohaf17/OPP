using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal class Data_For_Matrixes : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "2 3 4 \n 2 3 4 \n 4 5 6", "45 -5 5 \n 90 -2 2 \n 2 -3 54" };
            yield return new object[] { "2 -3 4 \n 22 3 4 \n 4 -5 -6", "5 -5 0 \n 90 0 2 \n 2 -3 54" };
            yield return new object[] { "2 -32 4 \n 2 23 4 \n 4 5 62", "45\n 90 -2 2 \n 2 -3" };
            yield return new object[] { "2 3 4 \n 2 3 4 \n 4 5 6", "45 -5 5 \n 90 -2 2 \n 2 -3 54" };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
