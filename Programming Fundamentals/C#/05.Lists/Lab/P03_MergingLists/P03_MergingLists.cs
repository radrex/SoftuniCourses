namespace P03_MergingLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P03_MergingLists
    {
        static void Main(string[] args)
        {
            List<int> arr1 = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToList();

            List<int> arr2 = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToList();

            List<int> zipped = new List<int>();

            if (arr1.Count >= arr2.Count)
            {
                for (int i = 0; i < arr1.Count; i++)
                {
                    zipped.Add(arr1[i]);
                    if (i < arr2.Count)
                    {
                        zipped.Add(arr2[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr2.Count; i++)
                {
                    if (i < arr1.Count)
                    {
                        zipped.Add(arr1[i]);
                    }
                    zipped.Add(arr2[i]);
                }
            }

            Console.WriteLine(String.Join(" ", zipped));
        }
    }
}
