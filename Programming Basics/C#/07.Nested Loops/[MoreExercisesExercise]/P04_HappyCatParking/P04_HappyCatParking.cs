namespace P04_HappyCatParking
{
    using System;

    class P04_HappyCatParking
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double total = 0.0;

            for (int day = 1; day <= days; day++)
            {
                double price = 0.0;

                for (int hour = 1; hour <= hours; hour++)
                {
                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        price += 2.50;
                    }
                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        price += 1.25;
                    }
                    else
                    {
                        price += 1.00;
                    }
                }

                Console.WriteLine($"Day: {day} - {price:F2} leva");
                total += price;
            }

            Console.WriteLine($"Total: {total:F2} leva");
        }
    }
}
