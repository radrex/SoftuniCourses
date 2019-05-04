namespace P08_HotelRoom
{
    using System;

    class P08_HotelRoom
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0.0;
            double apartmentPrice = 0.0;

            switch (month)
            {
                case "May":
                    studioPrice = nights * 50.0;
                    apartmentPrice = nights * 65.0;
                    if (nights > 7 && nights <= 14)
                    {
                        studioPrice *= 0.95;
                    }
                    else if (nights > 14)
                    {
                        studioPrice *= 0.70;
                        apartmentPrice *= 0.90;
                    }
                    break;

                case "June":
                    studioPrice = nights * 75.20;
                    apartmentPrice = nights * 68.70;
                    if (nights > 14)
                    {
                        studioPrice *= 0.80;
                        apartmentPrice *= 0.90;
                    }
                    break;

                case "July":
                    studioPrice = nights * 76.00;
                    apartmentPrice = nights * 77.00;
                    if (nights > 14)
                    {
                        apartmentPrice *= 0.90;
                    }
                    break;

                case "August":
                    studioPrice = nights * 76.00;
                    apartmentPrice = nights * 77.00;
                    if (nights > 14)
                    {
                        apartmentPrice *= 0.90;
                    }
                    break;

                case "September":
                    studioPrice = nights * 75.20;
                    apartmentPrice = nights * 68.70;
                    if (nights > 14)
                    {
                        studioPrice *= 0.80;
                        apartmentPrice *= 0.90;
                    }
                    break;

                case "October":
                    studioPrice = nights * 50.0;
                    apartmentPrice = nights * 65.0;
                    if (nights > 7 && nights <= 14)
                    {
                        studioPrice *= 0.95;
                    }
                    else if (nights > 14)
                    {
                        studioPrice *= 0.70;
                        apartmentPrice *= 0.90;
                    }
                    break;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice:F2} lv.");
        }
    }
}
