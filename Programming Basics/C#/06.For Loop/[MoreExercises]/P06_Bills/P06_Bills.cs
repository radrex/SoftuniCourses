namespace P06_Bills
{
    using System;

    class P06_Bills
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            decimal electricityBill = 0.0M;
            decimal water = 0.0M;
            decimal internet = 0.0M;
            decimal other = 0.0M;

            for (int i = 0; i < months; i++)
            {
                decimal electricity = decimal.Parse(Console.ReadLine());
                electricityBill += electricity;
                water += 20.0M;
                internet += 15.0M;
                other += (electricity + 20.0M + 15.0M) * 1.20M;        
            }

            Console.WriteLine($"Electricity: {electricityBill:F2} lv");
            Console.WriteLine($"Water: {water:F2} lv");
            Console.WriteLine($"Internet: {internet:F2} lv");
            Console.WriteLine($"Other: {other:F2} lv");
            Console.WriteLine($"Average: {(electricityBill + water + internet + other) / months:F2} lv");
        }
    }
}
