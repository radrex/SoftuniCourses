namespace P04_EvenTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_EvenTimes
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 1);
                }
                else
                {
                    numbers[number]++;
                } 
            }

            foreach (var number in numbers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}
