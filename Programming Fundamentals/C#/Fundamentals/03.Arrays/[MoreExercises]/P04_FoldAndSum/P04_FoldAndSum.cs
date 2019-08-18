namespace P04_FoldAndSum
{
    using System;
    using System.Linq;

    class P04_FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            int[] innerArr = new int[nums.Length / 2];
            int[] foldedArr = new int[innerArr.Length];

            int innerArrStartingIndex = innerArr.Length / 2;
            int foldedArrPart2StartIndex = foldedArr.Length / 2;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < innerArrStartingIndex)  // Fill first part of the folded array
                {
                    int count = 0;
                    for (int m = foldedArrPart2StartIndex - 1; m >= 0; m--)
                    {
                        foldedArr[m] = nums[i + count];
                        count++;
                    }
                    i = innerArrStartingIndex - 1; // Move to the inner array start index
                }
                else if (i == innerArrStartingIndex) // Fill the inner Array
                {
                    for (int k = 0; k < innerArr.Length; k++)
                    {
                        innerArr[k] = nums[i + k];
                    }

                    i += innerArr.Length - 1;   // Move to the last index of the first array
                }
                else
                {
                    int count = 0;
                    for (int s = foldedArrPart2StartIndex - 1; s >= 0; s--)
                    {
                        foldedArr[foldedArrPart2StartIndex + count] = nums[s + i];
                        count++;
                    }
                    break;  // Arrays filled, break the loop
                }
            }

            int[] summedArr = new int[foldedArr.Length];
            for (int i = 0; i < summedArr.Length; i++)
            {
                summedArr[i] = foldedArr[i] + innerArr[i];
            }

            Console.WriteLine(String.Join(" ", summedArr));
        }
    }
}