namespace P07_RepeatString
{
    using System;

    class P07_RepeatString
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = RepeatString(sequence, count);
            Console.WriteLine(result);
        }

        public static string RepeatString(string sequence, int count)
        {
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                result += sequence;
            }

            return result;
        }
    }
}