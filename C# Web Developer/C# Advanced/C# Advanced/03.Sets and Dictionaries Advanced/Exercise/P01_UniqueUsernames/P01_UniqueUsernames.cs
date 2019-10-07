namespace P01_UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    class P01_UniqueUsernames
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join(Environment.NewLine, usernames));
        }
    }
}
