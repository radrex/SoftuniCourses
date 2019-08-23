namespace P06_CharityCampaign
{
    using System;

    class P06_CharityCampaign
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakesSum = cakes * 45;
            double wafflesSum = waffles * 5.80;
            double pancakesSum = pancakes * 3.20;

            double totalSum = (cakesSum + wafflesSum + pancakesSum) * bakers;
            double result = (totalSum * days) - ((totalSum * days) * 0.125);

            Console.WriteLine($"{result:F2}");
        }
    }
}
