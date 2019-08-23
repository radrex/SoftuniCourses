namespace P08_Clock
{
    using System;

    class P08_Clock
    {
        static void Main(string[] args)
        {
            for (int hours = 0; hours <= 23; hours++)
            {
                for (int minutes = 0; minutes <= 59; minutes++)
                {
                    Console.WriteLine($"{hours} : {minutes}");
                }
            }
        }
    }
}
