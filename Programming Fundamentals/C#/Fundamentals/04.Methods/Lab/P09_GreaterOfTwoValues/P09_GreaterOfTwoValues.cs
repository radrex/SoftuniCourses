namespace P09_GreaterOfTwoValues
{
    using System;

    class P09_GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    int maxInt = GetMax(a, b);
                    Console.WriteLine(maxInt);
                    break;

                case "char":
                    char symbol1 = char.Parse(Console.ReadLine());
                    char symbol2 = char.Parse(Console.ReadLine());
                    char maxSymbol = GetMax(symbol1, symbol2);
                    Console.WriteLine(maxSymbol);
                    break;

                case "string":
                    string str1 = Console.ReadLine();
                    string str2 = Console.ReadLine();
                    string maxStr = GetMax(str1, str2);
                    Console.WriteLine(maxStr);
                    break;
            }
        }

        public static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }

        public static char GetMax(char symbol1, char symbol2)
        {
            return symbol1 > symbol2 ? symbol1 : symbol2;
        }

        public static string GetMax(string str1, string str2)
        {
            int value = str1.CompareTo(str2);

            if (value == 1)         // str1 > str2
            {
                return str1;
            }
            else if (value == -1)   // str1 < str2
            {
                return str2;
            }

            return str1;    // value == 0, str1 == str2
        }
    }
}