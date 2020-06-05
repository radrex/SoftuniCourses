namespace P02_FromLeftToTheRight
{
    using System;
    using System.Linq;

    class P02_FromLeftToTheRight
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long[] nums = Console.ReadLine()
                                     .Split()
                                     .Select(long.Parse)
                                     .ToArray();
                long sum = 0;
                long biggerNum = 0;

                if (nums[0].CompareTo(nums[1]) >= 0)
                {
                    biggerNum = nums[0];
                }
                else if (nums[0].CompareTo(nums[1]) < 0)
                {
                    biggerNum = nums[1];
                }

                while (biggerNum != 0)
                {
                    sum += biggerNum % 10;
                    biggerNum /= 10;
                }

                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}