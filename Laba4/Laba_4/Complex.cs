using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    internal class Complex:IMyNumber<Complex>
    {
        double re;
        double im;
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        public Complex Add(Complex that)
        {
            double new_re=this.re+that.re;
            double new_im=this.im+that.im;
            return new Complex(new_re, new_im);
        }
        public Complex Subtract(Complex that)
        {
            double new_re = this.re - that.re;
            double new_im = this.im - that.im;
            return new Complex(new_re, new_im);
        }
        public Complex Multiply(Complex that)
        {
            double new_re = this.re*that.re-this.im*that.im;
            double new_im = this.re*that.im+that.im*this.re;
            return new Complex(new_re, new_im);
        }
        public Complex Divide(Complex that)
        {
            if (that == null)
                throw new ArgumentNullException(nameof(that));

            if (that.re == 0 && that.im == 0)
                throw new DivideByZeroException();

            double new_re = (this.re * that.re + this.im * that.im)/(that.re*that.re+that.im*that.im);
            double new_im = (this.im*that.re-this.re*that.im)/ (that.re * that.re + that.im * that.im);
            return new Complex(new_re, new_im);
        }
        public override string ToString()
        {
            return this.re + " " + "+" + " (" + this.im + "i)";
        }
        public int CompareTo(Complex that)
        {
            if (that == null)
            {
                throw new ArgumentNullException(nameof(that), "The fraction to compare must be non-null.");
            }


            if ( this.re< that.re)
            {
                return -1;
            }
            else if (this.re > that.re)
            {
                return 1;
            }
            else if(this.im<that.im)
            {
                return -1;
            }
            else if (this.im > that.im)
            {
                return 1;
            }
            
                return 0;
            
        }
    }
}
