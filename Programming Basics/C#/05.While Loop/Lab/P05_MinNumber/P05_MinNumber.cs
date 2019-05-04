namespace P05_MinNumber
{
    using System;

    class P05_MinNumber
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;
            int n = int.Parse(Console.ReadLine());

            while (n > 0)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < min)
                {
                    min = number;
                }

                n--;
            }

            Console.WriteLine(min);
        }
    }
}
