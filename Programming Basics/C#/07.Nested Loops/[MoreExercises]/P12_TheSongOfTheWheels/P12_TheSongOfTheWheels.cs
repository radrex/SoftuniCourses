namespace P12_TheSongOfTheWheels
{
    using System;
    using System.Text;

    class P12_TheSongOfTheWheels
    {
        static void Main(string[] args)
        {
            int controlValue = int.Parse(Console.ReadLine());
            string password = string.Empty;
            int pwCount = 0;
            StringBuilder sb = new StringBuilder();

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (controlValue == a * b + c * d)
                            {
                                if (a < b && c > d)
                                {
                                    sb.Append($"{a}{b}{c}{d} ");
                                    pwCount++;
                                    if (pwCount == 4)
                                    {
                                        password = $"{a}{b}{c}{d}";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("No!");
            }
            else
            {
                Console.WriteLine($"Password: {password}");
            }
        }
    }
}
