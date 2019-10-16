namespace P05_DateModifier
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier dateModifier = new DateModifier(date1, date2);
            Console.WriteLine(dateModifier.GetDaysDifference(date1, date2));
        }
    }
}
