namespace P05_WordFilter
{
    using System;
    using System.Linq;

    class P05_WordFilter
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                                    .Split()
                                    .Where(w => w.Length % 2 == 0)
                                    .ToArray();

            Console.WriteLine(String.Join(Environment.NewLine, words));
        }
    }
}