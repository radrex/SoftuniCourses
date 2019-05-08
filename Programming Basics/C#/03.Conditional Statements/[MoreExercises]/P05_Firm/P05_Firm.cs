namespace P05_Firm
{
    using System;

    class P05_Firm
    {
        static void Main(string[] args)
        {
            int hoursRequired = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double workingHours = Math.Floor((days * 0.90) * 8 + (workers * 2 * days));

            if (workingHours >= hoursRequired)
            {
                Console.WriteLine($"Yes!{workingHours - hoursRequired} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursRequired - workingHours} hours needed.");
            }
        }
    }
}
