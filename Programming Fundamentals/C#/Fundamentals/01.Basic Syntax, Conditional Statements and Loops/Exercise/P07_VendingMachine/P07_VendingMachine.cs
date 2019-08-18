namespace P07_VendingMachine
{
    using System;

    class P07_VendingMachine
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double coins = 0.0;

            while (command != "Start")
            {
                double coin = double.Parse(command);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    coins += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                command = Console.ReadLine();
            }

            string product = Console.ReadLine().ToLower();
            while (product != "end")
            {
                switch (product)
                {
                    case "nuts":
                        if (coins >= 2.0)
                        {
                            Console.WriteLine($"Purchased {product}");
                            coins -= 2.0;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "water":
                        if (coins >= 0.7)
                        {
                            Console.WriteLine($"Purchased {product}");
                            coins -= 0.7;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "crisps":
                        if (coins >= 1.5)
                        {
                            Console.WriteLine($"Purchased {product}");
                            coins -= 1.5;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "soda":
                        if (coins >= 0.8)
                        {
                            Console.WriteLine($"Purchased {product}");
                            coins -= 0.8;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "coke":
                        if (coins >= 1.0)
                        {
                            Console.WriteLine($"Purchased {product}");
                            coins -= 1.0;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                product = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Change: {coins:F2}");
        }
    }
}