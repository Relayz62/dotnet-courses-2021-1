using System;

namespace MathLibrary
{
    public static class MathFunctions
    {
        public static long Factorial(int number)
        {
            int factorial = 1;
            for (int i = number; i > 1; i--)
                factorial *= i;
            return factorial;
        }
        public static double Power(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}
