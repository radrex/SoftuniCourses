namespace P04_Largest3Numbers
{
    using System;
    using System.Linq;

    class P04_Largest3Numbers
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray()
                                .OrderByDescending(n => n)
                                .ToArray();

            Console.WriteLine(String.Join(" ", nums.Take(3)));
        }
    }
}