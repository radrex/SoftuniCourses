namespace P07_FootballLeague
{
    using System;

    class P07_FootballLeague
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());
            int A = 0;
            int B = 0;
            int V = 0;
            int G = 0;

            for (int i = 0; i < fans; i++)
            {
                char sector = char.Parse(Console.ReadLine());

                switch (sector)
                {
                    case 'A': A++; break;
                    case 'B': B++; break;
                    case 'V': V++; break;
                    case 'G': G++; break;
                }
            }

            Console.WriteLine($"{(double)A / fans * 100.0:F2}%");
            Console.WriteLine($"{(double)B / fans * 100.0:F2}%");
            Console.WriteLine($"{(double)V / fans * 100.0:F2}%");
            Console.WriteLine($"{(double)G / fans * 100.0:F2}%");
            Console.WriteLine($"{(double)fans / stadiumCapacity * 100.0:F2}%");
        }
    }
}
