namespace P04_BackIn30Minutes
{
    using System;

    class P04_BackIn30Minutes
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalMinutes = (hours * 60) + minutes + 30;

            hours = totalMinutes / 60;
            minutes = totalMinutes - (hours * 60);
            if (hours == 24)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}