using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectLaba11
{
    internal class Data_For_Square : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1,4 };
            yield return new object[] { -2, 232,23 };
            yield return new object[] { 3, 9, 12 };
            yield return new object[] { 4, 4, 2 }; 
        }
        IEnumerator IEnumerable.GetEnumerator() =>GetEnumerator();
    }
    internal class Data_For_Operations : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1, 3, 2, 0,3 };
            yield return new object[] { 2, 23, 3,25,21,6 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    internal class Data_For_Cube : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1, 6,12 };
            yield return new object[] { -2, 232, 23 };
            yield return new object[] { 3, 9, 12 };
            yield return new object[] { 4, 64, 96,48 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    //internal class Data_For_Line : IEnumerable<object[]>
    //{
    //    public IEnumerator<object[]> GetEnumerator()
        
    //        yield
    //    }
    //}
}
