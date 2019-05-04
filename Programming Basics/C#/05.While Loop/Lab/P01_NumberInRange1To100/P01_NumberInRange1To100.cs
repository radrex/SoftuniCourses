namespace P01_NumberInRange1To100
{
    using System;

    class P01_NumberInRange1To100
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            while (number < 1 || number > 100)
            {
                Console.WriteLine("Invalid number!");
                number = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {number}");
        }
    }
}
