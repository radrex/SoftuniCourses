namespace P05_GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            string comparisonElement = Console.ReadLine();
            Console.WriteLine(CountGreater(boxes, comparisonElement));
        }

        public static int CountGreater<T>(List<Box<T>> list, T element)
            where T : IComparable<T>
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
