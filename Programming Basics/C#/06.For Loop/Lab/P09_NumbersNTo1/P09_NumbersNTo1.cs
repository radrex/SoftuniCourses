namespace P09_NumbersNTo1
{
    using System;

    class P09_NumbersNTo1
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = n; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
