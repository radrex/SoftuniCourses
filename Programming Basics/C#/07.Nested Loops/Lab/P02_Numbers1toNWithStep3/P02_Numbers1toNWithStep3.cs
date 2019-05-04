namespace P02_Numbers1toNWithStep3
{
    using System;

    class P02_Numbers1toNWithStep3
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i+=3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
