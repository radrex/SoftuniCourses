namespace P04_MetricConverter
{
    using System;

    class P04_MetricConverter
    {
        static void Main(string[] args)
        {
            double value = double.Parse(Console.ReadLine());
            string inputMetric = Console.ReadLine();
            string outputMetric = Console.ReadLine();

            if (inputMetric == "mm")
            {
                value /= 1000;
            }
            else if (inputMetric == "cm")
            {
                value /= 100;
            }

            if (outputMetric == "mm")
            {
                value *= 1000;
            }
            else if (outputMetric == "cm")
            {
                value *= 100;
            }

            Console.WriteLine($"{value:F3}");
        }
    }
}
