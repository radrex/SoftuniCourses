namespace P02_VowelsCount
{
    using System;
    using System.Linq;

    class P02_VowelsCount
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintVowelsCount(input);
        }

        public static void PrintVowelsCount(string input)
        {
            char[] vowels = new char[] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
            int vowelsCount = 0;

            foreach (char symbol in input)
            {
                if (vowels.Contains(symbol))
                {
                    vowelsCount++;
                }
            }

            Console.WriteLine(vowelsCount);
        }
    }
}