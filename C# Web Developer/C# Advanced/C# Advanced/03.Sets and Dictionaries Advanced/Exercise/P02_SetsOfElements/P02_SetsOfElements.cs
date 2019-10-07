namespace P02_SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_SetsOfElements
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            int[] setLengths = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToArray();

            while (setLengths[0]-- > 0)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            while (setLengths[1]-- > 0)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            var intersected = set1.Intersect(set2);
            Console.WriteLine(String.Join(" ", intersected));
        }
    }
}
