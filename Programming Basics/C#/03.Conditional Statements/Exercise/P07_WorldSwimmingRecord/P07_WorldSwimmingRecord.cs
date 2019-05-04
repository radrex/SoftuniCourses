namespace P07_WorldSwimmingRecord
{
    using System;

    class P07_WorldSwimmingRecord
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double metersInSecond = double.Parse(Console.ReadLine());

            double time = (distanceInMeters * metersInSecond) + (Math.Floor(distanceInMeters / 15) * 12.5);

            if (recordInSeconds <= time)
            {
                Console.WriteLine($"No, he failed! He was {time - recordInSeconds:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:F2} seconds.");
            }
        }
    }
}
