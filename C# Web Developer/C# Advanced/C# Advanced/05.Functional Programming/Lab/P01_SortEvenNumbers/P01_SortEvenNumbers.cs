namespace P01_SortEvenNumbers
{
    using System;
    using System.Linq;

    class P01_SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Func<int, bool> predicate = x => x % 2 == 0;
            IOrderedEnumerable<int> evenNumbers = Console.ReadLine()
                                                         .Split(", ")
                                                         .Select(int.Parse)
                                                         .Where(predicate)
                                                         .OrderBy(x => x);
            Console.WriteLine(String.Join(", ", evenNumbers));
        }
    }
}
