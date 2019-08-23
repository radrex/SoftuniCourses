namespace P09_MultiplyBy2
{
    using System;

    class P09_MultiplyBy2
    {
        static void Main(string[] args)
        {     
            while (true)
            {
                double num = double.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Negative number!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Result: {num * 2:F2}");
                }
            }
        }
    }
}
