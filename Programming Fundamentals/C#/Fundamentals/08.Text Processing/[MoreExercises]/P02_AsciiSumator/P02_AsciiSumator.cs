namespace P02_AsciiSumator
{
    using System;

    class P02_AsciiSumator
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            string randomStr = Console.ReadLine();
            int sum = 0;

            foreach (char symbol in randomStr)
            {
                if (symbol > start && symbol < end)
                {
                    sum += symbol;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
