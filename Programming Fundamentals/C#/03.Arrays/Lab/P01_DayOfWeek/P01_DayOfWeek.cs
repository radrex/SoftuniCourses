namespace P01_DayOfWeek
{
    using System;

    class P01_DayOfWeek
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            Console.WriteLine((day >= 1 && day <= 7) ? days[day - 1] : "Invalid day!");
        }
    }
}