namespace P04_NewHouse
{
    using System;

    class P04_NewHouse
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double flowers = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double price = 0.0;

            switch (type)
            {
                case "Roses":
                    if (flowers > 80)
                    {
                        price = (flowers * 5.0) * 0.90;                       
                    }
                    else
                    {
                        price = flowers * 5.0;
                    }
                    break;

                case "Dahlias":
                    if (flowers > 90)
                    {
                        price = (flowers * 3.80) * 0.85;
                    }
                    else
                    {
                        price = flowers * 3.80;
                    }
                    break;

                case "Tulips":
                    if (flowers > 80)
                    {
                        price = (flowers * 2.80) * 0.85;
                    }
                    else
                    {
                        price = flowers * 2.80;
                    }
                    break;

                case "Narcissus":
                    if (flowers < 120)
                    {
                        price = (flowers * 3.0) * 1.15;
                    }
                    else
                    {
                        price = flowers * 3.0;
                    }
                    break;

                case "Gladiolus":
                    if (flowers < 80)
                    {
                        price = (flowers * 2.50) * 1.20;
                    }
                    else
                    {
                        price = flowers * 2.50;
                    }
                    break;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowers} {type} and {budget - price:F2} leva left.");
            }
            else 
            {
                Console.WriteLine($"Not enough money, you need {price - budget:F2} leva more.");
            }
        }
    }
}
