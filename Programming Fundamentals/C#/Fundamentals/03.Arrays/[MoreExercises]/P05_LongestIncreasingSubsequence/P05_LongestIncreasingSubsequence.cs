namespace P05_LongestIncreasingSubsequence
{
    using System;
    using System.Linq;

    class P05_LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int maxLength = 0;
            int lastIndex = -1;
            int[] len = new int[nums.Length];
            int[] prev = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;

                for (int k = 0; k < i; k++)
                {
                    if (nums[k] < nums[i] && len[k] + 1 > len[i])
                    {
                        len[i] = len[k] + 1;
                        prev[i] = k;
                    }
                }

                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    lastIndex = i;
                }
            }

            int[] LIS = new int[maxLength];
            int currentIndex = maxLength - 1;

            while (lastIndex != -1)
            {
                LIS[currentIndex] = nums[lastIndex];
                currentIndex--;
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(" ", LIS));
        }
    }
}