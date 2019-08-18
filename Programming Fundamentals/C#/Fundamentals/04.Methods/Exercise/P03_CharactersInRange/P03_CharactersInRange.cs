namespace P03_CharactersInRange
{
    using System;

    class P03_CharactersInRange
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintCharactersBetween(start, end);
        }

        public static void PrintCharactersBetween(char start, char end)
        {
            string sequence = string.Empty;
            if (start < end)
            {
                for (char i = (char)(start + 1); i < end; i++)
                {
                    sequence += $"{i} ";
                }
            }
            else
            {
                for (char i = (char)(end + 1); i < start; i++)
                {
                    sequence += $"{i} ";
                }
            }

            Console.WriteLine(sequence.TrimEnd());
        }
    }
}