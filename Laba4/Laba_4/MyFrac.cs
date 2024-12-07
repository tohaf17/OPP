using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Laba_4
{
    internal class MyFrac:IMyNumber<MyFrac>,IComparable<MyFrac>
    {
        BigInteger nom;
        BigInteger denom;
        public MyFrac(BigInteger _nom, BigInteger _denom)
        {
            if (_denom == 0)
                throw new ArgumentException("Denom cannot be zero.", nameof(_denom));

            BigInteger gcd = GCD(_nom, _denom);
            nom = (_denom > 0) ? _nom / gcd : -(_nom / gcd);
            denom = BigInteger.Abs(_denom / gcd);
        }

        private static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return BigInteger.Abs(a);
        }

        public MyFrac Add(MyFrac that)
        {
            BigInteger new_nom = this.nom * that.denom + that.nom * this.denom;
            BigInteger new_denom = this.denom * that.denom;
            return new MyFrac(new_nom, new_denom);
        }
        public MyFrac Subtract(MyFrac that)
        {
            BigInteger new_nom = this.nom * that.denom - that.nom * this.denom;
            BigInteger new_denom = this.denom * that.denom;
            return new MyFrac(new_nom, new_denom);
        }
        public MyFrac Multiply(MyFrac that)
        {
            BigInteger new_nom = this.nom *that.nom;
            BigInteger new_denom = this.denom * that.denom;
            return new MyFrac(new_nom, new_denom);
        }
        public MyFrac Divide(MyFrac that)
        {
            if (that.nom == 0)
                throw new DivideByZeroException();

            BigInteger new_nom = this.nom * that.denom;
            BigInteger new_denom = this.denom * that.nom;
            return new MyFrac(new_nom, new_denom);
        }
        public override string ToString()
        {
            if (this.nom / this.denom != 0 && this.nom % this.denom != 0)
            {
                BigInteger chastka = this.nom / this.denom;
                BigInteger ostacha = this.nom % this.denom;
                if (chastka < 0)
                {
                    return "-(" + BigInteger.Abs(chastka) + "+" + new MyFrac(BigInteger.Abs(ostacha), BigInteger.Abs(this.denom)) + ")";
                }
                else
                {
                    return "(" + chastka + "+" + new MyFrac(ostacha, this.denom) + ")";
                }
            }
            else if (this.nom % this.denom == 0)
            {
                return "(" + this.nom / this.denom + ")";
            }
            else
            {
                return nom + "/" + denom;
            }
        }
        public int CompareTo(MyFrac x)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x), "The fraction to compare must be non-null.");
            }

            BigInteger leftSide = this.nom * x.denom;
            BigInteger rightSide = x.nom * this.denom;

            if (leftSide < rightSide)
            {
                return -1;
            }
            else if (leftSide > rightSide)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
