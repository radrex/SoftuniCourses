namespace P08_MagicSum
{
    using System;
    using System.Linq;

    class P08_MagicSum
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int magicSum = int.Parse(Console.ReadLine());

            for (int n1 = 0; n1 < nums.Length - 1; n1++)
            {
                for (int n2 = n1 + 1; n2 <= nums.Length - 1; n2++)
                {
                    if (nums[n1] + nums[n2] == magicSum)
                    {
                        Console.WriteLine($"{nums[n1]} {nums[n2]}");
                    }
                }
            }
        }
    }
}