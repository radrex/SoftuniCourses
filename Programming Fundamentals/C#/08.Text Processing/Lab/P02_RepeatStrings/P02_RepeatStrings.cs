namespace P02_RepeatStrings
{
    using System;
    using System.Text;

    class P02_RepeatStrings
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();

            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb);
        }
    }
}