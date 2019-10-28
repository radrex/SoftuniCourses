namespace P06_BinarySearch
{
    using System;

    class P06_BinarySearch
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int index = BinarySearch(arr, 8, 0, arr.Length);

            Console.WriteLine(String.Join(", ", arr));
            Console.WriteLine($"Index: {index}");
            Console.WriteLine($"Number: {arr[index]}");
        }

        public static int BinarySearch(int[] arr, int item, int start, int end)
        {
            while (end >= start)
            {
                int mid = (start + end) / 2;
                if (arr[mid] < item)
                {
                    start = mid + 1;
                }

                else if (arr[mid] > item)
                {
                    end = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            throw new InvalidOperationException("Item not found");
        }
    }
}
