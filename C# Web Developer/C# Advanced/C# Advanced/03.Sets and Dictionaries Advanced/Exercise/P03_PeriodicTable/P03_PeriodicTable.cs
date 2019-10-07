namespace P03_PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P03_PeriodicTable
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicalElements = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());

            while (n-- > 0)
            {
                string[] elements = Console.ReadLine().Split();
                elements.ToList().ForEach(x => chemicalElements.Add(x));
            }

            Console.WriteLine(String.Join(" ", chemicalElements));
        }
    }
}
