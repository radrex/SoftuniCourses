namespace P02_SleepyTomCat
{
    using System;

    class P02_SleepyTomCat
    {
        static void Main(string[] args)
        {
            int restDays = int.Parse(Console.ReadLine());

            int restDaysPlay = restDays * 127;
            int workDaysPlay = (365 - restDays) * 63;
            int totalPlayMinutes = restDaysPlay + workDaysPlay;

            if (30000 > totalPlayMinutes)
            {
                int hours = (30000 - totalPlayMinutes) / 60;
                int minutes = (30000 - totalPlayMinutes) - hours * 60;

                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
            else
            {
                int hours = (totalPlayMinutes - 30000) / 60;
                int minutes = (totalPlayMinutes - 30000) - hours * 60;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
        }
    }
}
