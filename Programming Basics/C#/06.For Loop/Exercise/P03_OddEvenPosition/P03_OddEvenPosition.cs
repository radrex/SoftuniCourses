namespace P03_OddEvenPosition
{
    using System;

    class P03_OddEvenPosition
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double OddSum = 0;
            double OddMin = double.MaxValue;
            double OddMax = double.MinValue;

            double EvenSum = 0;
            double EvenMin = double.MaxValue;
            double EvenMax = double.MinValue;
            if (n == 1)
            {
                double num = double.Parse(Console.ReadLine());

                Console.WriteLine($"OddSum={num:F2},");
                Console.WriteLine($"OddMin={num:F2},");
                Console.WriteLine($"OddMax={num:F2},");

                Console.WriteLine("EvenSum=0.00,");
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else if (n == 0)
            {

                Console.WriteLine("OddSum=0.00,");
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");

                Console.WriteLine("EvenSum=0.00,");
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    double num = double.Parse(Console.ReadLine());

                    if (i % 2 != 0)
                    {
                        if (num < OddMin)
                        {
                            OddMin = num;
                        }
                        if (num > OddMax)
                        {
                            OddMax = num;
                        }
                        OddSum += num;
                    }
                    else if (i % 2 == 0)
                    {
                        if (num < EvenMin)
                        {
                            EvenMin = num;
                        }
                        if (num > EvenMax)
                        {
                            EvenMax = num;
                        }
                        EvenSum += num;
                    }
                }
                Console.WriteLine($"OddSum={OddSum:F2},");
                Console.WriteLine($"OddMin={OddMin:F2},");
                Console.WriteLine($"OddMax={OddMax:F2},");

                Console.WriteLine($"EvenSum={EvenSum:F2},");
                Console.WriteLine($"EvenMin={EvenMin:F2},");
                Console.WriteLine($"EvenMax={EvenMax:F2}");
            }
        }
    }
}
