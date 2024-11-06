using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using help;
using Laba1;

namespace TestProjectLaba11
{
    public class Unit_Test_Line
    {
        [Theory]
        [InlineData(3,4,5,-3,1)]
        public void Containing_Point(double A,double B,double C,double x,double y)
        {
            var example = new Line(A,B,C);
            Assert.True(example.ContainsPoint(x, y));
        }
        [Theory]
        [InlineData(3,4,5,2,4,5,0.0, 1.25)]
        [InlineData(3,4,5,3,4,5,null,null)]
        [InlineData(1,-1,0,1,-1,-1,null,null)]
        public void Intersection(double A,double B,double C,double X,double Y,double Z,double? expectedX,double? expectedY)
        {
            var one = new Line(A, B, C);
            var two= new Line(X,Y,Z);
            if (one.Equals(two))
            {
                Assert.Fail("The infinity solutions");
                return;
            }
            (double, double)? expected = expectedX.HasValue && expectedY.HasValue
                                  ? (expectedX.Value, expectedY.Value)
                                  : null;

            Assert.Equal(expected, one.Intersection(two));
        }
    }
}
