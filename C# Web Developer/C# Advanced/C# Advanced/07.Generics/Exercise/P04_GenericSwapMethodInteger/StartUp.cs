namespace P04_GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            int[] indices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(boxes, indices[0], indices[1]);

            Console.WriteLine(String.Join(Environment.NewLine, boxes));
        }

        public static void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
