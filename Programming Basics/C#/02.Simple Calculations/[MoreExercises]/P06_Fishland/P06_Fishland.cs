namespace P06_Fishland
{
    using System;

    class P06_Fishland
    {
        static void Main(string[] args)
        {
            double mackerelPricePerKg = double.Parse(Console.ReadLine());
            double spratPricePerKg = double.Parse(Console.ReadLine());

            double beltedBonitoKgs = double.Parse(Console.ReadLine());
            double scadKgs = double.Parse(Console.ReadLine());
            double clamKgs = double.Parse(Console.ReadLine());

            double beltedBonitoPricePerKg = mackerelPricePerKg *= 1.60;
            double scadPricePerKg = spratPricePerKg *= 1.80;

            double beltedBonitoTotalPrice = beltedBonitoPricePerKg * beltedBonitoKgs;
            double scadTotalPrice = scadPricePerKg * scadKgs;
            double clamTotalPrice = clamKgs * 7.50;

            double totalPrice = beltedBonitoTotalPrice + scadTotalPrice + clamTotalPrice;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
