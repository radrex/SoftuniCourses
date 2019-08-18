namespace P06_ReplaceRepeatingChars
{
    using System;

    class P06_ReplaceRepeatingChars
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string replaced = string.Empty;
            replaced += text[0];

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] != text[i + 1])
                {
                    replaced += text[i + 1];
                }
            }

            Console.WriteLine(replaced);
        }
    }
}