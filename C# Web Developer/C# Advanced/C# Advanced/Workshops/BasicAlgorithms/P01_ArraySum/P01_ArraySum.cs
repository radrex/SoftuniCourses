namespace P01_ArraySum
{
    using System;

    class P01_ArraySum
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int index = 0;
            int result = SumArray(arr, index);
            Console.WriteLine(result);
        }

        private static int SumArray(int[] arr, int index)
        {
            if (index < arr.Length)
            {
                return arr[index] + SumArray(arr, index + 1);
            }

            return 0;
        }
    }
}
