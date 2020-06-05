namespace P04_CenturiesToMinutes
{
    using System;

    class P04_CenturiesToMinutes
    {
        static void Main(string[] args)
        {
            byte centuries = byte.Parse(Console.ReadLine());
            ushort years = (ushort)(centuries * 100);
            uint days = (uint)(years * 365.2422);
            uint hours = days * 24;
            uint minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}