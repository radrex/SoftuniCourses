namespace P05_BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P05_BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            int[] bombParameters = Console.ReadLine()
                                          .Split()
                                          .Select(int.Parse)
                                          .ToArray();
            int bombNumber = bombParameters[0];
            int bombPower = bombParameters[1];

            for (int i = 0; i < bombPower; i++)
            {
                for (int k = 0; k < numbers.Count; k++)
                {
                    if (numbers[k] == bombNumber)
                    {
                        if (k - 1 >= 0)
                        {
                            numbers.RemoveAt(k - 1);
                            k--;
                        }

                        if (k + 1 < numbers.Count)
                        {
                            numbers.RemoveAt(k + 1);
                        }
                    }
                }
            }

            numbers.RemoveAll(n => n == bombNumber);
            Console.WriteLine(numbers.Sum());
        }
    }
}