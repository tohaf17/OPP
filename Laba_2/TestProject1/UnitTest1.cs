
using Lab4;
using TestProject1;
using Xunit.Abstractions;
namespace TestProject1
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Theory]
        [ClassData(typeof(MyFrac_TestData))]
        public void Addition(long a, long b, long c, long d)
        {
            MyFrac first = new MyFrac(a, b);
            MyFrac second = new MyFrac(c, d);

            long expect_nom = a * d + c * b;
            long expect_denom = b * d;
            MyFrac expected_sum = new MyFrac(expect_nom, expect_denom);

            MyFrac actual_sum = first + second;

            output.WriteLine($"Expected: {expected_sum}, Actual: {actual_sum}");

            Assert.Equal(0, actual_sum.CompareTo(expected_sum));
        }


        [Theory]
        [ClassData(typeof(MyFrac_TestData))]
        public void Subtraction(long a, long b, long c, long d)
        {
            MyFrac first = new MyFrac(a, b);
            MyFrac second = new MyFrac(c, d);

            long expect_nom = a * d - c * b;
            long expect_denom = b * d;
            MyFrac expected_subtract = new MyFrac(expect_nom, expect_denom);

            MyFrac actual_subtract = first - second;

            output.WriteLine($"Expected: {expected_subtract}, Actual: {actual_subtract}");

            Assert.Equal(0, actual_subtract.CompareTo(expected_subtract));
        }
        [Theory]
        [ClassData(typeof(MyFrac_TestData))]
        public void Multiplication(long a, long b, long c, long d)
        {
            MyFrac first = new MyFrac(a, b);
            MyFrac second = new MyFrac(c, d);

            long expect_nom = a * c;
            long expect_denom = b * d;
            MyFrac expected_multi = new MyFrac(expect_nom, expect_denom);

            MyFrac actual_multi = first * second;

            output.WriteLine($"Expected: {expected_multi}, Actual: {actual_multi}");

            Assert.Equal(0, actual_multi.CompareTo(expected_multi));
        }
        [Theory]
        [ClassData(typeof(MyFrac_TestData))]
        public void Division(long a, long b, long c, long d)
        {
            MyFrac first = new MyFrac(a, b);
            MyFrac second = new MyFrac(c, d);

            long expect_nom = a * d;
            long expect_denom = b * c;
            MyFrac expected_div = new MyFrac(expect_nom, expect_denom);

            MyFrac actual_div = first / second;

            output.WriteLine($"Expected: {expected_div}, Actual: {actual_div}");

            Assert.Equal(0, actual_div.CompareTo(expected_div));
        }

    }
}