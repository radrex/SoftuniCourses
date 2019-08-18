namespace P05_Messages
{
    using System;

    class P05_Messages
    {
        static void Main(string[] args)
        {
            int clicks = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 0; i < clicks; i++)
            {
                string digits = Console.ReadLine();
                int digitLength = digits.Length;
                int digit = digits[0] - '0';    // ASCII hack hehehe
                int offset = (digit - 2) * 3;

                if (digit == 0)
                {
                    message += (char)(digit + 32);
                    continue;
                }

                if (digit == 8 || digit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + digitLength - 1;
                message += (char)(letterIndex + 97);
            }

            Console.WriteLine(message);
        }
    }
}