namespace P01_UniquePINCodes
{
    using System;

    class P01_UniquePINCodes
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            for (int d1 = 1; d1 <= n1; d1++)
            {
                for (int d2 = 1; d2 <= n2; d2++)
                {
                    for (int d3 = 1; d3 <= n3; d3++)
                    {
                        if (d1 % 2 == 0 && d3 % 2 == 0)
                        {
                            if (d2 == 2 || d2 == 3 || d2 == 5 || d2 == 7)
                            {
                                Console.WriteLine($"{d1} {d2} {d3}");
                            }
                        }
                    }
                }
            }
        }
    }
}
