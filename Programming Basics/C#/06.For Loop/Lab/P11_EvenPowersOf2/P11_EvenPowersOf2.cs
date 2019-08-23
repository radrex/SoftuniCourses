namespace P11_EvenPowersOf2
{
    using System;

    class P11_EvenPowersOf2
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int current = 1;
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(current);
                current *= 4;
            }
        }
    }
}
