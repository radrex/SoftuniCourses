namespace P01_DataTypes
{
    using System;

    class P01_DataTypes
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine().ToLower();
            switch (type)
            {
                case "int":
                    int integer = int.Parse(Console.ReadLine());
                    PrintResult(integer);
                    break;

                case "real":
                    double realNumber = double.Parse(Console.ReadLine());
                    PrintResult(realNumber);
                    break;

                case "string":
                    string str = Console.ReadLine();
                    PrintResult(str);
                    break;
            }
        }

        public static void PrintResult(int number)
        {
            Console.WriteLine(number * 2);
        }

        public static void PrintResult(double number)
        {
            Console.WriteLine($"{number * 1.5:F2}");
        }

        public static void PrintResult(string str)
        {
            Console.WriteLine($"${str}$");
        }
    }
}