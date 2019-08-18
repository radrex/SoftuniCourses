namespace P05_SpecialNumbers
{
    using System;

    class P05_SpecialNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string digits = i.ToString();
                int sum = 0;
                foreach (char digit in digits)
                {
                    int d = digit - '0'; // ASCII hack hehehe
                    sum += d;
                }

                switch (sum)
                {
                    case 5:
                    case 7:
                    case 11:
                        Console.WriteLine($"{i} -> True");
                        break;
                    default:
                        Console.WriteLine($"{i} -> False");
                        break;

                }
            }
        }
    }
}