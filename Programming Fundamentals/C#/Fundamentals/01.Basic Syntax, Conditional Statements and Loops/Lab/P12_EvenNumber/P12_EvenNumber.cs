namespace P12_EvenNumber
{
    using System;

    class P12_EvenNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while (n % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {Math.Abs(n)}");
        }
    }
}