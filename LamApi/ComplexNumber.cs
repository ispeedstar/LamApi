using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamApi
{
    class ComplexNumber
    {
        private double realPart;
        private double imaginaryPart;

        public double Real
        {
            get
            {
                return (realPart);
            }
            set
            {
                realPart = value;
            }
        }


        public double Imaginary
        {
            get
            {
                return (imaginaryPart);
            }
            set
            {
                imaginaryPart = value;
            }
        }

        // Constructor
        public ComplexNumber()
        {
            Real = 0.0;
            Imaginary = 0.0;
        }

        public ComplexNumber(double a, double b)
        {
            Real = a;
            Imaginary = b;
        }

        public static ComplexNumber operator+(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Real+y.Real, x.Imaginary+y.Imaginary);
        }

        public static ComplexNumber operator-(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Real-y.Real, x.Imaginary-y.Imaginary);
        }

        public static ComplexNumber operator*(ComplexNumber x, ComplexNumber y)
        {
            double a = x.Real*y.Real - x.Imaginary*y.Imaginary;
            double b = x.Imaginary*y.Real + x.Real*y.Imaginary;
            return new ComplexNumber(a,b);
        }
        
        public static ComplexNumber operator/(ComplexNumber x, ComplexNumber y)
        {
            double denom = y.Real*y.Real + y.Imaginary*y.Imaginary;
            double a = (x.Real*y.Real+x.Imaginary*y.Imaginary)/denom;
            double b = (x.Imaginary*y.Real - x.Real*y.Imaginary)/denom;
            return new ComplexNumber(a,b);
        }

        public static void Print(ComplexNumber x)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            sb.Append(x.Real);
            sb.Append(",");
            sb.Append(x.Imaginary);
            sb.Append(")");
            Console.WriteLine(sb.ToString());
        }

        public static void DoTest()
        {
            ComplexNumber x = new ComplexNumber(4.3, 8.2);
            ComplexNumber y = new ComplexNumber(3.3, 1.1);
            ComplexNumber ans = new ComplexNumber();

            ans = x + y;
            Print(ans);

            ans = x - y;
            Print(ans);

            ans = x * y;
            Print(ans);

            ans = x / y;
            Print(ans);
        }

    } // end class ComplexNumber
}
