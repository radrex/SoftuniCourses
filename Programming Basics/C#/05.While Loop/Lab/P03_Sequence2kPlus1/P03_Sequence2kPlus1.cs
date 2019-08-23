namespace P03_Sequence2kPlus1
{
    using System;

    class P03_Sequence2kPlus1
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int k = 1;

            while (k <= number)
            {
                Console.WriteLine(k);
                k = k * 2 + 1;
            }
        }
    }
}
