namespace P04_HotelReservation
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            decimal price = decimal.Parse(tokens[0]);
            int days = int.Parse(tokens[1]);
            Season season = Enum.Parse<Season>(tokens[2]);
            Discount discount = Discount.None;

            if (tokens.Length == 4)
            {
                discount = Enum.Parse<Discount>(tokens[3]);
            }

            decimal totalPrice = PriceCalculator.GetTotalPrice(price, days, season, discount);
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
