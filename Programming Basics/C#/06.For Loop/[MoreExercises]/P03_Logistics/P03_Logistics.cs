namespace P03_Logistics
{
    using System;

    class P03_Logistics
    {
        static void Main(string[] args)
        {
            int cargo = int.Parse(Console.ReadLine());

            int minibusTons = 0;
            int truckTons = 0;
            int trainTons = 0;

            for (int i = 0; i < cargo; i++)
            {
                int tons = int.Parse(Console.ReadLine());

                if (tons <= 3)
                {
                    minibusTons += tons;
                }
                else if (tons > 3 && tons <= 11)
                {
                    truckTons += tons;
                }
                else if (tons > 11)
                {
                    trainTons += tons;
                }
            }

            int totalTons = minibusTons + truckTons + trainTons;
            double average = (double)(minibusTons * 200 + truckTons * 175 + trainTons * 120) / totalTons;

            Console.WriteLine($"{average:F2}");
            Console.WriteLine($"{(double)minibusTons / totalTons * 100:F2}%");
            Console.WriteLine($"{(double)truckTons / totalTons * 100:F2}%");
            Console.WriteLine($"{(double)trainTons / totalTons * 100:F2}%");
        }
    }
}
