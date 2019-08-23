namespace P04_NumbersDividedBy3WithoutReminder
{
    using System;

    class P04_NumbersDividedBy3WithoutReminder
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
