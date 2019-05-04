namespace P07_TradeCommissions
{
    using System;

    class P07_TradeCommissions
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine().ToLower();
            double sales = double.Parse(Console.ReadLine());

            double comission = 0.0;

            if (city == "sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    comission = sales * 0.05;
                }
                else if (sales >= 500 && sales <= 1000)
                {
                    comission = sales * 0.07;
                }
                else if (sales >= 1000 && sales <= 10000)
                {
                    comission = sales * 0.08;
                }
                else if (sales >= 10000)
                {
                    comission = sales * 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                    return;
                }
            }
            else if (city == "varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    comission = sales * 0.045;
                }
                else if (sales >= 500 && sales <= 1000)
                {
                    comission = sales * 0.075;
                }
                else if (sales >= 1000 && sales <= 10000)
                {
                    comission = sales * 0.10;
                }
                else if (sales >= 10000)
                {
                    comission = sales * 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                    return;
                }
            }
            else if (city == "plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    comission = sales * 0.055;
                }
                else if (sales >= 500 && sales <= 1000)
                {
                    comission = sales * 0.08;
                }
                else if (sales >= 1000 && sales <= 10000)
                {
                    comission = sales * 0.12;
                }
                else if (sales >= 10000)
                {
                    comission = sales * 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                    return;
                }
            }
            else
            {
                Console.WriteLine("error");
                return;
            }

            Console.WriteLine($"{comission:F2}");
        }
    }
}
