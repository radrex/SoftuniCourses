using System;

namespace P01_SquareRoot
{
    public static class Calculator
    {
        public static double Sqrt(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(nameof(number), "Invalid number");
            }
            else if (number == 0)
            {
                return 0;
            }

            double root = 1;
            int i = 0;

            //The Babylonian Method for Computing Square Roots
            while (true)
            {
                i = i + 1;
                root = (number / root + root) / 2;
                if (i == number + 1) { break; }
            }

            return root;
        }
    }
}
