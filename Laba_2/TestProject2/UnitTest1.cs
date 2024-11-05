using System;
using Laba_2;
using Xunit.Abstractions;
namespace TestProject2
{
    public class UnitTest1
    {
        public readonly ITestOutputHelper output;
        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("2 3 4 \n                                         4 \n 4 5 6", "45 -5 5 \n 90 -2 2 \n 2 -3 54")]
        public void Sum_Of_Matrixes(string a, string b)
        {
            Matrix A = new Matrix(a);
            Matrix B = new Matrix(b);
            double[,] result = new double[3, 3]
                {
                    { 47, -2, 9 },
                    { 92, 1, 6 },
                    { 6, 2, 60 }
                };
            output.WriteLine((A + B).ToString());
            Assert.True(Matrix.Equals(result, A + B));
        }
        [Theory]
        [InlineData("2 3 4 \n 2 3 4 \n 4 5 6", "45 -5 5 \n 90 -2 2 \n 2 -3 54")]
        public void Multiplication_Of_Matrixes(string a, string b)
        {
            Matrix C = new Matrix(a);
            Matrix D = new Matrix(b);
            double[,] result = new double[3, 3]
                {
                    { 368, -28, 232 },
                    { 368, -28, 232 },
                    { 642, -48, 354 }
                };
            output.WriteLine((C * D).ToString());
            Assert.True(Matrix.Equals(result, C * D));
        }
        [Theory]
        [InlineData("2 -32 4 \n 2 23 4 \n 4 5 62")]
        public void Transported(string e)
        {
            Matrix A = new Matrix(e);
            double[,] result = new double[3, 3]
                {
                    { 2, 2, 4 },
                    { -32, 23, 5 },
                    { 4, 4, 62 }
                };
            output.WriteLine((A.Get_Transported_Copy()).ToString());
            Assert.True(Matrix.Equals(result, A.Get_Transported_Copy()));
        }
        [Theory]
        [InlineData("45 -5 5 \n 90 -2 2 \n 2 -3 54")]
        public void Determinator(string a)
        {
            Matrix A = new Matrix(a);
            double result = A.Determinant();
            Assert.Equal(18360, result);
        }
    }
}