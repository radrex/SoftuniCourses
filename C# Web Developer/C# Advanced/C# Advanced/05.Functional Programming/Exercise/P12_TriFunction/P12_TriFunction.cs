namespace P12_TriFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P12_TriFunction
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int, bool> isGreater = (x, y) => x.Sum(ch => ch) >= y;
            Func<Func<string, int, bool>, List<string>, string> returnFirst = (x, y) => y.FirstOrDefault(s => x(s, sum));

            string result = returnFirst(isGreater, names);
            Console.WriteLine(result);
        }
    }
}
