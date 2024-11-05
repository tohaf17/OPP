using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class MyFrac:IComparable<MyFrac>
    {
        private long nom { get; set; }
        private long denom { get; set; }

        public MyFrac(long _nom, long _denom)
        {
            if (_denom == 0)
            {
                throw new ArgumentException("Denominator cannot be zero");
            }

            long gcd = GCD(Math.Abs(_nom), Math.Abs(_denom));
            nom = _nom / gcd;
            denom = Math.Abs(_denom) / gcd; 

            
            if (_denom < 0)
            {
                nom = -nom;
            }
        }

        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }


        public override string ToString()
        {
            return nom + "/" + denom;
        }
        public string ToStringWithIntPart()
        {
            if (this.nom / this.denom != 0 && this.nom % this.denom != 0)
            {
                long chastka = this.nom / this.denom;
                long ostacha = this.nom % this.denom;
                if (chastka < 0)
                {
                    return "-(" + chastka + "+" + new MyFrac(ostacha, this.denom) + ")";
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
                return this.ToString();
            }
        }

        public double DoubleValue()
        {
            return this.nom / (double)this.denom;
        }

        public static MyFrac operator +(MyFrac first, MyFrac second)
        {
            long nom = first.nom * second.denom + second.nom * first.denom;
            long denom = first.denom * second.denom;
            return new MyFrac(nom, denom);
        }

        public static MyFrac operator -(MyFrac first, MyFrac second)
        {
            long nom = first.nom * second.denom - second.nom * first.denom;
            long denom = first.denom * second.denom;
            return new MyFrac(nom, denom);
        }

        public static MyFrac operator *(MyFrac first, MyFrac second)
        {
            long nom = first.nom * second.nom;
            long denom = first.denom * second.denom;
            return new MyFrac(nom, denom);
        }

        public static MyFrac operator /(MyFrac first, MyFrac second)
        {
            long nom = first.nom * second.denom;
            long denom = first.denom * second.nom;
            return new MyFrac(nom, denom);
        }

        public static MyFrac CalcExpr1(int length)
        {
            MyFrac result = new MyFrac(0, 1);
            int i = 1;
            while (i <= length)
            {
                MyFrac add = new MyFrac(1, i * (i + 1));
                result = result+add;
                i++;
            }

            return result;
        }

        public static MyFrac CalcExpr2(int length)
        {
            MyFrac result = new MyFrac(1, 1);
            for (int i = 2; i <= length; i++)
            {
                MyFrac drib = new MyFrac(1, i * i);
                MyFrac difference = new MyFrac(1, 1)-drib;
                result *=difference;
            }
            return result;
        }
        public int CompareTo(MyFrac x)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x), "The fraction to compare must be non-null.");
            }

            long leftSide = this.nom * x.denom;
            long rightSide = x.nom * this.denom;

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