namespace P06_ReversedChars
{
    using System;

    class P06_ReversedChars
    {
        static void Main(string[] args)
        {
            string sequence = string.Empty;
            string reversed = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                sequence += Console.ReadLine();
            }

            for (int i = sequence.Length - 1; i >= 0; i--)
            {
                reversed += sequence[i] + " ";
            }

            reversed.TrimEnd();
            Console.WriteLine(reversed);
        }
    }
}