namespace P09_CharsToString
{
    using System;

    class P09_CharsToString
    {
        static void Main(string[] args)
        {
            string sequence = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                sequence += symbol;
            }

            Console.WriteLine(sequence);
        }
    }
}