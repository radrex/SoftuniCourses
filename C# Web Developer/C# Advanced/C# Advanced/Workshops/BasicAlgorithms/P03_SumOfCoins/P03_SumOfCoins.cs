namespace P03_SumOfCoins
{
    using System;

    class P03_SumOfCoins
    {
        static void Main(string[] args)
        {
            int[] coins = { 10, 10, 1, 1, 1, 2, 2, 5, 5, 10 };
            int targetSum = 10;
            int currentSum = 0;

            Array.Sort(coins);
            Array.Reverse(coins);

            int counter = 0;

            while (currentSum < targetSum)
            {
                if (counter == coins.Length)
                {
                    break;
                }

                if (coins[counter] + currentSum <= targetSum)
                {
                    currentSum += coins[counter];
                }

                counter++;
            }

            if (currentSum == targetSum)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}
