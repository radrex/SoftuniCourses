namespace P05_Coins
{
    using System;

    class P05_Coins
    {
        static void Main(string[] args)
        {
            decimal change = decimal.Parse(Console.ReadLine());
            int coins = 0;

            while (change > 0)
            {
                if (change >= 2.0M)
                {
                    change -= 2.0M;
                }
                else if (change >= 1.0M)
                {
                    change -= 1.0M;
                }
                else if (change >= 0.50M)
                {
                    change -= 0.50M;
                }
                else if (change >= 0.20M)
                {
                    change -= 0.20M;
                }
                else if (change >= 0.10M)
                {
                    change -= 0.10M;
                }
                else if (change >= 0.05M)
                {
                    change -= 0.05M;
                }
                else if (change >= 0.02M)
                {
                    change -= 0.02M;
                }
                else if (change >= 0.01M)
                {
                    change -= 0.01M;
                }

                coins++;
            }

            Console.WriteLine(coins);
        }
    }
}
