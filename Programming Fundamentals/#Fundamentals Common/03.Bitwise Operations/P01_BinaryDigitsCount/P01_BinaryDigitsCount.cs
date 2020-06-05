namespace P01_BinaryDigitsCount
{
    using System;

    class P01_BinaryDigitsCount
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());

            string binary = Convert.ToString(n, 2);
            int count = 0;

            foreach (char digit in binary)
            {
                if (digit == b)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
