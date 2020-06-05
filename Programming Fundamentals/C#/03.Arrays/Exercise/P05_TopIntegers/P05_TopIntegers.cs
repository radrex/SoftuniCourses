namespace P05_TopIntegers
{
    using System;
    using System.Linq;

    class P05_TopIntegers
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();
            string topIntegers = string.Empty;

            for (int i = 0; i < integers.Length; i++)
            {
                bool isBigger = true;
                for (int k = i + 1; k < integers.Length; k++)   //-1
                {
                    if (integers[i] <= integers[k])
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (isBigger)
                {
                    topIntegers += integers[i] + " ";
                }
            }

            Console.WriteLine(topIntegers.TrimEnd());
        }
    }
}