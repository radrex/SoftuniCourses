namespace P03_Vacation
{
    using System;

    class P03_Vacation
    {
        static void Main(string[] args)
        {
            double requiredFunds = double.Parse(Console.ReadLine());
            double availableFunds = double.Parse(Console.ReadLine());

            int spendingDays = 0;
            int days = 0;

            while (spendingDays < 5 && availableFunds < requiredFunds)
            {
                string action = Console.ReadLine().ToLower();
                double amount = double.Parse(Console.ReadLine());

                switch (action)
                {
                    case "spend":
                        days++;
                        spendingDays++;
                        if (availableFunds > amount)
                        {
                            availableFunds -= amount;
                        }
                        else
                        {
                            availableFunds = 0;
                        }
                        break;
                    case "save":
                        days++;
                        spendingDays = 0;
                        availableFunds += amount;
                        break;
                }
            }

            if (spendingDays == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }

            if (availableFunds >= requiredFunds)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
