namespace P07_SchoolCamp
{
    using System;

    class P07_SchoolCamp
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            decimal price = 0.0M;
            string sport = string.Empty;

            switch (season)
            {
                case "Winter":
                    switch (groupType)
                    {
                        case "boys":
                            price = students * 9.60M * nights;
                            sport = "Judo";
                            break;

                        case "girls":
                            price = students * 9.60M * nights;
                            sport = "Gymnastics";
                            break;

                        case "mixed":
                            price = students * 10.00M * nights;
                            sport = "Ski";
                            break;
                    }
                    break;

                case "Spring":
                    switch (groupType)
                    {
                        case "boys":
                            price = students * 7.20M * nights;
                            sport = "Tennis";
                            break;

                        case "girls":
                            price = students * 7.20M * nights;
                            sport = "Athletics";
                            break;

                        case "mixed":
                            price = students * 9.50M * nights;
                            sport = "Cycling";
                            break;
                    }
                    break;

                case "Summer":
                    switch (groupType)
                    {
                        case "boys":
                            price = students * 15.00M * nights;
                            sport = "Football";
                            break;

                        case "girls":
                            price = students * 15.00M * nights;
                            sport = "Volleyball";
                            break;

                        case "mixed":
                            price = students * 20.00M * nights;
                            sport = "Swimming";
                            break;
                    }
                    break;
            }

            if (students >= 50)
            {
                price *= 0.50M;
            }
            else if (students >= 20 && students < 50)
            {
                price *= 0.85M;
            }
            else if (students >= 10 && students < 20)
            {
                price *= 0.95M;
            }

            Console.WriteLine($"{sport} {price:F2} lv.");
        }
    }
}
