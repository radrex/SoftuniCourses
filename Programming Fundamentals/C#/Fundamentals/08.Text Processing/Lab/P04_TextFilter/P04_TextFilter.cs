namespace P04_TextFilter
{
    using System;

    class P04_TextFilter
    {
        static void Main(string[] args)
        {
            string[] forbiddenWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (string forbiddenWord in forbiddenWords)
            {
                text = text.Replace(forbiddenWord, new string('*', forbiddenWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}