namespace P03_Coding
{
    using System;

    class P03_Coding
    {
        static void Main(string[] args)
        {
            string inputNum = Console.ReadLine();
            for (int i = inputNum.Length - 1; i >= 0; i--)
            {
                char currentDigit = inputNum[i];
                int currentDigitToNumber = int.Parse(currentDigit.ToString());

                if (currentDigitToNumber == 0)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }

                for (int n = 1; n <= currentDigitToNumber; n++)
                {
                    Console.Write((char)(currentDigitToNumber + 33));
                }
                Console.WriteLine();
            }
        }
    }
}
