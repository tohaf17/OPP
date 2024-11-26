using System.Numerics;
using Xunit.Abstractions;

namespace Laba_4
{
    public class Test_Complex
    {
        private readonly ITestOutputHelper output;

        public Test_Complex(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(3, 1, 4, 342)]
        public void Add_Test(double a,double  b, double c, double d)
        {
            Complex first = new Complex(a, b);
            Complex second = new Complex(c, d);
            Complex result = first.Add(second);
            Complex result_accurate = new Complex(7, 343);
            output.WriteLine(result + "=" + result_accurate);
            Assert.Equal(0, result.CompareTo(result_accurate));

        }

        [Theory]
        [InlineData(3, 4, -3, 9)]
        public void Subtract_Test(int a, int b, int c, int d)
        {
            Complex first = new Complex(a, b);
            Complex second = new Complex(c, d);
            Complex result = first.Subtract(second);
            Complex result_accurate = new Complex(6, -5);
            output.WriteLine(result + "=" + result_accurate);
            Assert.Equal(0, result.CompareTo(result_accurate));
        }

        [Theory]
        [InlineData(3, 4, -3, 9)]
        public void Multiply_Test(int a, int b, int c, int d)
        {
            Complex first = new Complex(a, b);
            Complex second = new Complex(c, d);
            Complex result = first.Multiply(second);
            Complex result_accurate = new Complex(-45, 54);
            output.WriteLine(result + "=" + result_accurate);
            Assert.Equal(0, result.CompareTo(result_accurate));
        }

        [Theory]
        [InlineData(2, 2, 2, 2)]
        public void Divide_Test(int a, int b, int c, int d)
        {
            Complex first = new Complex(a, b);
            Complex second = new Complex(c, d);
            Complex result = first.Divide(second);
            Complex result_accurate = new Complex(1, 0);
            output.WriteLine(result + "=" + result_accurate);
            Assert.Equal(0, result.CompareTo(result_accurate));
        }
    }
}