namespace P02_KnightsOfHonor
{
    using System;
    using System.Linq;

    class P02_KnightsOfHonor
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> action = name => name.ToList().ForEach(x => Console.WriteLine($"Sir {x}"));
            action(names);

            // Second Option
            //Action<string[]> action = Print;
            //action(names);
        }

        private static void Print(string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
