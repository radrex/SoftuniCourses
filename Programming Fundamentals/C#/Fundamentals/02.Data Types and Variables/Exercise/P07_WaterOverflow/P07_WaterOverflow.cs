namespace P07_WaterOverflow
{
    using System;

    class P07_WaterOverflow
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            byte water = 0;

            for (int i = 0; i < n; i++)
            {
                ushort liters = ushort.Parse(Console.ReadLine());
                if (liters <= 255 && ((255 - water) - liters) >= 0)
                {
                    water += (byte)liters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(water);
        }
    }
}