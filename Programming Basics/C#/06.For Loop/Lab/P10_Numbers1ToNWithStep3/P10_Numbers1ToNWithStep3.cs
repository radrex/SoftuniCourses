namespace P10_Numbers1ToNWithStep3
{
    using System;

    class P10_Numbers1ToNWithStep3
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
