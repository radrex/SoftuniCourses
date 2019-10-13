namespace P03_CountUppercaseWords
{
    using System;
    using System.Linq;

    class P03_CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> predicate = word => char.IsUpper(word[0]);
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .Where(predicate)
                              .ToList()
                              .ForEach(word => Console.WriteLine(word));
        }
    }
}
