using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.Console;
using System.Xml.Linq;

namespace Laba1
{
    internal class Line
    {
        private double A;
        private double B;
        private double C;

        public Line(double A = 1, double B = 1, double C = 1)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => A,
                    1 => B,
                    2 => C,
                    _ => throw new Exception("Out of range")
                };
            }
            set
            {
                _ = index switch
                {
                    0 => (A = value),
                    1 => (B = value),
                    2 => (C = value),
                    _ => throw new Exception("Out of range")
                };
            }

        }

        public override string ToString()
        {
            string signB = this[1] >= 0 ? "+" : "-";
            string signC = this[2] >= 0 ? "+" : "-";

            return $"Line equation: {this[0]}x {signB} {Math.Abs(this[1])}y {signC} {Math.Abs(this[2])} = 0";
        }

        public void Input()
        {
            WriteLine("Input the numbers\n");
            Write("A: ");
            A = double.Parse(ReadLine());
            Write("B: ");
            B = double.Parse(ReadLine());
            Write("C: ");
            C = double.Parse(ReadLine());
        }
        public (double, double)? Intersection(Line other)
        {
            double det = A * other.B - B * other.A;

            if (det == 0)
            {
                return null;

            }
            else
            {
                double x = (other.B * -C - B * -other.C) / det;
                double y = (other.A * -C - A * -other.C) / det;
                return (x, y);
            }
        }
        public bool ContainsPoint(double x, double y)
        {
            return Abs(A * x + B * y + C) < 1e-10;
        }
        public override bool Equals(object obj)
        {
            if (obj is Line other)
            {
                return A == other.A && B == other.B && C == other.C;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (int)A ^(int)B ^ (int)C;
        }
    }
}
