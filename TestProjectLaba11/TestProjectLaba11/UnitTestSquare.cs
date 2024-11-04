using help;
using System;
namespace TestProjectLaba11
{
    public class UnitTestSquare
    {
        [Theory]
        [ClassData(typeof(Data_For_Square))]
        public void Square_Square_And_Perimeter(int a, int first, int second)
        {
            var e = new TSquare(a);
            var square = e.Square();
            Assert.Equal(first, square);
            var perimeter = e.Perimeter();
            Assert.Equal(second, perimeter);
        }
        [Theory]
        [InlineData(3,2)]
        public void Square_Comparing(int a,int b)
        {
            var one=new TSquare(a);
            var two=new TSquare(b);
            var three = new TCube(3);
            Assert.True(two.CompareTo(three)<0,"One is less than two");
        }

        [Theory]
        [ClassData(typeof(Data_For_Operations))]
        public static void Square_Operations(int a,int b,int k,int sum,int dif,int mul)
        {
            TSquare one = new TSquare(a);
            TSquare two = new TSquare(b);
            Assert.Equal(sum, (one+two).side);
            Assert.Equal(dif, (one - two).side);
            Assert.Equal(sum, (one*k).side);
        }
        
    }
}