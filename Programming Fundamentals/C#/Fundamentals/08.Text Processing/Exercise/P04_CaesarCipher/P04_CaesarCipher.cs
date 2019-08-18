namespace P04_CaesarCipher
{
    using System;

    class P04_CaesarCipher
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string encrypted = string.Empty;

            foreach (char symbol in text)
            {
                encrypted += (char)(symbol + 3);
            }

            Console.WriteLine(encrypted);
        }
    }
}