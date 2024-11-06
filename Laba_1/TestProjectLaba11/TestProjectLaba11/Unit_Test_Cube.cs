using help;
using System;
namespace TestProjectLaba11
{
    public class UnitTestCube
    {
        [Theory]
        [ClassData(typeof(Data_For_Cube))]
        public void Cube_Volume_Square_And_Perimeter(int a, int volume,int square,int perimeter)
        {
            var e = new TCube(a);
            var _volume = e.Volume();
            Assert.Equal(volume, _volume);
            var _square = e.Square();
            Assert.Equal(square, _square);
            var _perimeter = e.Perimeter();
            Assert.Equal(perimeter, _perimeter);
        }
        [Theory]
        [InlineData(2, 3)]
        public void Cube_Comparing(int a, int b)
        {
            var one = new TSquare(a);
            var two = new TSquare(b);
            Assert.True(one.CompareTo(two) < 0, "One is less than two");
        }

        [Theory]
        [ClassData(typeof(Data_For_Operations))]
        public static void Cube_Operations(int a, int b, int k, int sum, int dif, int mul)
        {
            TSquare one = new TSquare(a);
            TSquare two = new TSquare(b);
            Assert.Equal(sum, (one + two).side);
            Assert.Equal(dif, (one - two).side);
            Assert.Equal(sum, (one * k).side);//write for k*one
        }

    }
}