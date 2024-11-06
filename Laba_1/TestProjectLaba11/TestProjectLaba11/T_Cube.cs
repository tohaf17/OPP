using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace help
{
    internal class TCube : TSquare, IComparable<TCube>
    {
        public TCube(double side) : base(side) { }

        public double Volume() => Math.Pow(base.side, 3);

        public override string ToString() => "The cube side: " + side;

        // Площа поверхні куба
        public new double Square() => base.Square() * 6;

        // Периметр куба
        public new double Perimeter() => base.Perimeter() * 3;

        public static TCube operator +(TCube a, TCube k) =>
            (a.side + k.side > 0) ? new TCube(a.side + k.side) : throw new Exception("Input another cube");

        public static TCube operator -(TCube a, TCube k) =>
            (a.side - k.side > 0) ? new TCube(a.side - k.side) : throw new Exception("Input another cube");

        public static TCube operator *(TCube a, double k) =>
            (k > 0) ? new TCube(a.side * k) : throw new Exception("Input positive k");
        public int CompareTo(object? other)
        {
            if (other is TCube d)
            {
                if (this == null && other == null) return 0;
                if (this == null) return -1;
                if (other == null) return 1;
                return this.side.CompareTo(d.side);
            }
            else
            {
                throw new Exception("Exception");
            }

        }
    }
}
