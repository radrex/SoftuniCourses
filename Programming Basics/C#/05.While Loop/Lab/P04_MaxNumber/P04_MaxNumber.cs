namespace P04_MaxNumber
{
    using System;

    class P04_MaxNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            int max = int.MinValue;

            while (count < n)
            {
                int num = int.Parse(Console.ReadLine());
                count++;
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine(max);
        }
    }
}
