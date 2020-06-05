namespace P09_SumOfOddNumbers
{
    using System;

    class P09_SumOfOddNumbers
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());

            int odd = 1;
            int sum = 0;
            while (nums != 0)
            {
                Console.WriteLine(odd);
                sum += odd;
                odd += 2;
                nums--;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}