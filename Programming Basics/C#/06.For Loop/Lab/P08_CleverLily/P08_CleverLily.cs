namespace P08_CleverLily
{
    using System;

    class P08_CleverLily
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int moneyYears = 0;
            int toyYears = 0;
            double money = 0.0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    moneyYears++;
                }
                else
                {
                    toyYears++;
                }
            }

            for (int i = 1; i <= moneyYears; i++)
            {
                money += 10 * i;
            }

            money += (toyYears * toyPrice) - moneyYears;
            double diff = Math.Abs(washingMachinePrice - money);

            if (money >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {diff:F2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:F2}");
            }
        }
    }
}
