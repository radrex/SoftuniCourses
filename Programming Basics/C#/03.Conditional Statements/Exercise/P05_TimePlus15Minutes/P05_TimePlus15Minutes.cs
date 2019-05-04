namespace P05_TimePlus15Minutes
{
    using System;

    class P05_TimePlus15Minutes
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());

            int timeInMinutes = startHour * 60 + startMinutes;
            int timePlus15 = timeInMinutes + 15;

            int finalHour = timePlus15 / 60;
            int finalMinutes = timePlus15 % 60;

            if (finalHour >= 24)
            {
                finalHour -= 24;
            }

            if (finalMinutes < 10)
            {
                Console.WriteLine($"{finalHour}:0{finalMinutes}");
            }
            else
            {
                Console.WriteLine($"{finalHour}:{finalMinutes}");
            }
        }
    }
}
