namespace P08_SkiTrip
{
    using System;

    class P08_SkiTrip
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine()) - 1;
            string roomType = Console.ReadLine().ToLower();
            string rate = Console.ReadLine().ToLower();

            bool lessThan10Days = days < 10;
            bool between10and15Days = days >= 10 && days <= 15;
            bool moreThan15Days = days > 15;

            double price = 0.0;

            if (roomType == "room for one person")
            {
                price = days * 18.00;
            }
            else if (roomType == "apartment")
            {
                if (lessThan10Days)
                {
                    price = (days * 25) * 0.70;
                }
                else if (between10and15Days)
                {
                    price = (days * 25) * 0.65;
                }
                else if (moreThan15Days)
                {
                    price = (days * 25) * 0.50;
                }
            }
            else if (roomType == "president apartment")
            {
                if (lessThan10Days)
                {
                    price = (days * 35) * 0.90;
                }
                else if (between10and15Days)
                {
                    price = (days * 35) * 0.85;
                }
                else if (moreThan15Days)
                {
                    price = (days * 35) * 0.80;
                }
            }

            if (rate == "positive")
            {
                price *= 1.25;
            }
            else if (rate == "negative")
            {
                price *= 0.90;
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}
