using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using help;

namespace help
{
    internal class TSquare : IComparable<TSquare>
    {
        private double _side;

        public double side
        {
            get
            {
                return _side;
            }
            set
            {
                if (value > 0)
                {
                    _side = value;
                }
                else
                {
                    throw new Exception("Input valid data");
                }
            }
        }
        public TSquare(double side)
        {
            this.side = side;
        }
        public TSquare()
        {
            this.side = 25;
        }
        public TSquare(TSquare other)
        {
            this.side = other.side;
        }
        override public string ToString() => "The square side: " + side.ToString();
        public double Square() => side * side;
        public double Perimeter() => 4 * side;

        public static TSquare operator +(TSquare a, TSquare k) =>
            (a.side + k.side > 0) ? new TSquare(a.side + k.side) : throw new Exception("Input another k");
        public static TSquare operator -(TSquare a, TSquare k) =>
            (a.side - k.side > 0) ? new TSquare(a.side - k.side) : throw new Exception("Input another k");
        public static TSquare operator *(TSquare a, double k) =>
            (k > 0) ? new TSquare(a.side * k) : throw new Exception("Input positive k");
        public static TSquare operator *(double k,TSquare a) =>
            (k > 0) ? new TSquare(k*a.side) : throw new Exception("Input positive k");
        public int CompareTo(TSquare? other)
        {
            if (this == null && other == null) return 0;
            if (other == null) return 1;
            if (this.GetType() != other.GetType()) return 0;

            return this.side.CompareTo(other.side);
        }

    }
}
