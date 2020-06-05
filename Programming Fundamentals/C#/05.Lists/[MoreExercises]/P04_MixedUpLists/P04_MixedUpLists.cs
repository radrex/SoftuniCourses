namespace P04_MixedUpLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                                     .Split()
                                     .Select(int.Parse)
                                     .ToList();
            List<int> second = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToList();
            List<int> mixed = new List<int>();
            List<int> sorted = new List<int>();

            while (first.Count != 0 && second.Count != 0)
            {
                mixed.Add(first.First());
                first.Remove(first.First());

                mixed.Add(second.Last());
                second.Remove(second.Last());
            }

            if (first.Count > 0)
            {
                foreach (int number in mixed)
                {
                    if (number > first.Min() && number < first.Max())
                    {
                        sorted.Add(number);
                    }
                }
            }
            else
            {
                foreach (int number in mixed)
                {
                    if (number > second.Min() && number < second.Max())
                    {
                        sorted.Add(number);
                    }
                }
            }

            sorted.Sort();
            Console.WriteLine(String.Join(" ", sorted));
        }
    }
}