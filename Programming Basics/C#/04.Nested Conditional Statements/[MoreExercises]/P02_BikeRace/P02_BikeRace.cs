namespace P02_BikeRace
{
    using System;

    class P02_BikeRace
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string trace = Console.ReadLine().ToLower();
            decimal juniorTax = 0.0M;
            decimal seniorTax = 0.0M;

            switch (trace)
            {
                case "trail":
                    juniorTax = 5.50M;
                    seniorTax = 7.00M;
                    break;

                case "cross-country":
                    juniorTax = 8.00M;
                    seniorTax = 9.50M;

                    if (juniors + seniors >= 50)
                    {
                        juniorTax *= 0.75M;
                        seniorTax *= 0.75M;
                    }

                    break;

                case "downhill":
                    juniorTax = 12.25M;
                    seniorTax = 13.75M;
                    break;

                case "road":
                    juniorTax = 20.00M;
                    seniorTax = 21.50M;
                    break;
            }

            decimal price = (juniors * juniorTax + seniors * seniorTax) * 0.95M;
            Console.WriteLine($"{price:F2}");
        }
    }
}
