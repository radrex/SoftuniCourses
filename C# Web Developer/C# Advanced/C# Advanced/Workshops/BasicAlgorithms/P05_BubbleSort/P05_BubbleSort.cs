namespace P05_BubbleSort
{
    using System;

    class P05_BubbleSort
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 4, 2, 1 };
            BubbleSort(arr);

            Console.WriteLine(String.Join(", ", arr));
        }

        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
