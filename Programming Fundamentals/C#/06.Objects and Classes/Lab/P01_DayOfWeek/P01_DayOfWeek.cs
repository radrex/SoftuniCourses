namespace P01_DayOfWeek
{
    using System;
    using System.Globalization;

    class P01_DayOfWeek
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();
            DateTime parsedDate = DateTime.ParseExact(date, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(parsedDate.DayOfWeek);
        }
    }
}