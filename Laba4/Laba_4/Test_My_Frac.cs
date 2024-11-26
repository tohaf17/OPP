using System.Numerics;
using Xunit.Abstractions;

namespace Laba_4
{
    public class Test_My_Frac
    {
        private readonly ITestOutputHelper output;

        public Test_My_Frac(ITestOutputHelper output)
        { 
            this.output = output;
        }

        [Theory]
        [InlineData(322342342342342342,124124124112,12341241241,12412414124)]
        public void Add_Test(BigInteger a,BigInteger b,BigInteger c,BigInteger d)
        {
            MyFrac first=new MyFrac(a,b);
            MyFrac second=new MyFrac(c,d);
            MyFrac result=first.Add(second);
            MyFrac result_accurate = new MyFrac(15, 36);
            output.WriteLine(result + "=" + result_accurate);
            Assert.Equal(0,result.CompareTo(result_accurate));
            
        }

        [Theory]
        [InlineData(3, 4, -3, 9)]
        public void Subtract_Test(int a, int b, int c, int d)
        {
            MyFrac first = new MyFrac(a, b);
            MyFrac second = new MyFrac(c, d);
            MyFrac result = first.Subtract(second);
            MyFrac result_accurate = new MyFrac(13, 12);
            output.WriteLine(result + "=" + result_accurate);
            Assert.Equal(result, result_accurate);
        }

        [Theory]
        [InlineData(3, 4, -3, 9)]
        public void Multiply_Test(int a, int b, int c, int d)
        {
            MyFrac first = new MyFrac(a, b);
            MyFrac second = new MyFrac(c, d);
            MyFrac result = first.Multiply(second);
            MyFrac result_accurate = new MyFrac(-1, 4);
            output.WriteLine(result + "=" + result_accurate);
            Assert.Equal(result, result_accurate);
            
        }

        [Theory]
        [InlineData(3, 4, -3, 9)]
        public void Divide_Test(int a, int b, int c, int d)
        {
            MyFrac first = new MyFrac(a, b);
            MyFrac second = new MyFrac(c, d);
            MyFrac result = first.Divide(second);
            MyFrac result_accurate = new MyFrac(9, -4);
            output.WriteLine(result + "=" + result_accurate);
            Assert.Equal(result, result_accurate);
            
        }
    }
}