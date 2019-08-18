namespace P07_MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    class P07_MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            int biggestNum = nums.Last();
            int biggestCount = 1;

            int currentNum = nums.Last();
            int currentCount = 1;

            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] != nums[i - 1])
                {
                    currentNum = nums[i - 1];
                    currentCount = 1;
                    continue;
                }

                currentCount++;

                if (currentCount >= biggestCount)
                {
                    biggestCount = currentCount;
                    biggestNum = currentNum;
                }
            }

            string sequence = string.Empty;
            for (int i = 0; i < biggestCount; i++)
            {
                sequence += $"{biggestNum} ";
            }

            Console.WriteLine(sequence.TrimEnd());
        }
    }
}