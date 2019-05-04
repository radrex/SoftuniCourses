namespace P06_DivideWithoutRemainder
{
    using System;

    class P06_DivideWithoutRemainder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double firstCounter = 0;
            double secondCounter = 0;
            double thirdCounter = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    firstCounter++;
                }
                if (num % 3 == 0)
                {
                    secondCounter++;
                }
                if (num % 4 == 0)
                {
                    thirdCounter++;
                }
            }
            double p1 = (firstCounter / n) * 100;
            double p2 = (secondCounter / n) * 100;
            double p3 = (thirdCounter / n) * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
