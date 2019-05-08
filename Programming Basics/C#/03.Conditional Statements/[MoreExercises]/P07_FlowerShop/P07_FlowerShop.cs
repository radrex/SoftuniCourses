namespace P07_FlowerShop
{
    using System;

    class P07_FlowerShop
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());              // Price - 3.25
            int hyacinths = int.Parse(Console.ReadLine());              // Price - 4.00
            int roses = int.Parse(Console.ReadLine());                  // Price - 3.50
            int cactuses = int.Parse(Console.ReadLine());               // Price - 8.00
            double giftPrice = double.Parse(Console.ReadLine());        // Tax - 5.00%

            double profit = ((magnolias * 3.25) + (hyacinths * 4.00) + (roses * 3.50) + (cactuses * 8.00)) * 0.95;

            if (giftPrice > profit)
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(giftPrice - profit)} leva.");
            }
            else
            {
                Console.WriteLine($"She is left with {Math.Floor(profit - giftPrice)} leva.");
            }
        }
    }
}
