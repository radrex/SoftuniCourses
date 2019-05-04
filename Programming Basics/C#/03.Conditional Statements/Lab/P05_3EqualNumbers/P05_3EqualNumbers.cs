namespace P05_3EqualNumbers
{
    using System;

    class P05_3EqualNumbers
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            bool areEqul = num1 == num2 && num2 == num3;

            if (areEqul)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
