namespace P12_ToyShop
{
    using System;

    class P12_ToyShop
    {
        static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int talkingDolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double totalSum = (puzzles * 2.6) + (talkingDolls * 3.0) + (teddyBears * 4.1) + (minions * 8.2) + (trucks * 2.0);
            int toysCount = puzzles + talkingDolls + teddyBears + minions + trucks;

            double discount = 0.0;
            if (toysCount >= 50)
            {
                discount = totalSum * 0.25;
            }

            double totalPrice = totalSum - discount;
            totalPrice = totalPrice - (totalPrice * 0.10);

            if (holidayPrice <= totalPrice)
            {
                Console.WriteLine($"Yes! {totalPrice - holidayPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(totalPrice - holidayPrice):F2} lv needed.");
            }
        }
    }
}
