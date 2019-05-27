using System;

namespace Alyabiev.Task11.MyMathLib
{
    public static class MyMath
    {
        public static double Factorial(int _base)
        {
            double res = 1;
            for (int i = 2; i <= _base; i++)
            {
                res *= i;
            }
            return res;
        }

        public static double Power(double num, double _base)
        {
            //exp(n * LN(x));
            return Math.Exp(_base * Math.Log(num));
        }
    }
}