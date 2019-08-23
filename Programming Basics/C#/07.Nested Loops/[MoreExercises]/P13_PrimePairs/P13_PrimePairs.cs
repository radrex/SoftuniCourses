namespace P13_PrimePairs
{
    using System;

    class P13_PrimePairs
    {
        static void Main(string[] args)
        {
            int firstPair = int.Parse(Console.ReadLine());
            int secondPair = int.Parse(Console.ReadLine());
            int firstPairEnd = int.Parse(Console.ReadLine());
            int secondPairEnd = int.Parse(Console.ReadLine());

            for (int x1 = firstPair; x1 <= firstPair + firstPairEnd; x1++)
            {
                for (int x2 = secondPair; x2 <= secondPair + secondPairEnd; x2++)
                {
                    if (IsPrime(x1) && IsPrime(x2))
                    {
                        Console.WriteLine($"{x1}{x2}");
                    }
                }
            }
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}