namespace P09_OnTimeForTheExam
{
    using System;

    class P09_OnTimeForTheExam
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            int examTime = (hour * 60) + minute;

            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());
            int arrivalTime = (arrivalHour * 60) + arrivalMinute;

            int diff = examTime - arrivalTime;

            if (diff > 30)
            {
                Console.WriteLine("Early");

                if (diff > 59)
                {
                    int hours = diff / 60;
                    int mins = diff % 60;
                    Console.WriteLine($"{hours}:{mins:D2} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{diff} minutes before the start");
                }
            }
            else if (diff < 0)
            {
                Console.WriteLine("Late");
                int minsLate = Math.Abs(diff);
                if (minsLate > 59)
                {
                    int hours = minsLate / 60;
                    int mins = minsLate % 60;
                    Console.WriteLine($"{hours}:{mins:D2} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{minsLate} minutes after the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
                if (diff > 0)
                {
                    Console.WriteLine($"{diff} minutes before the start");
                }
            }
        }
    }
}
