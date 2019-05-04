namespace P10_Volleyball
{
    using System;

    class P10_Volleyball
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine()); 
            int homeWeekends = int.Parse(Console.ReadLine());

            int maxWeekends = 48; 
            double sofiaWeekends = maxWeekends - homeWeekends;

            double sofiaWeekendGames = sofiaWeekends * (3.0 / 4.0);
            double sofiaHolidayGames = holidays * (2.0 / 3.0);
            double games = sofiaWeekendGames + sofiaHolidayGames + homeWeekends;
            double leapBonusGames = games * 0.15;

            switch (yearType)
            {
                case "leap":
                    Console.WriteLine($"{Math.Floor(games + leapBonusGames)}");
                    break;

                case "normal":
                    Console.WriteLine($"{Math.Floor(games)}");
                    break;
            }
        }
    }
}
