namespace P09_SpiceMustFlow
{
    using System;

    class P09_SpiceMustFlow
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int extractedSpices = 0;
            int days = 0;

            while (yield >= 100)
            {
                extractedSpices += (yield - 26);
                yield -= 10;
                days++;
            }

            if (extractedSpices - 26 >= 0)
            {
                extractedSpices -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(extractedSpices);
        }
    }
}