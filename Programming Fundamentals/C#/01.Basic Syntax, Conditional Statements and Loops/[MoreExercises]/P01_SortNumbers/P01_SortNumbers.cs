namespace P01_SortNumbers
{
    using System;

    class P01_SortNumbers
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int max = Math.Max(Math.Max(num1, num2), num3);
            int min = Math.Min(Math.Min(num1, num2), num3);
            int mid = (num1 + num2 + num3) - (max + min);

            Console.WriteLine(max);
            Console.WriteLine(mid);
            Console.WriteLine(min);
        }
    }
}