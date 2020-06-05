namespace P04_MorseCodeTranslator
{
    using System;
    using System.Collections.Generic;

    class P04_MorseCodeTranslator
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morse = new Dictionary<string, char>()
            {
                {".-", 'A'}, {"-...", 'B'}, {"-.-.", 'C'}, {"-..", 'D'}, {".", 'E'}, {"..-.", 'F'}, {"--.", 'G'}, {"....", 'H'},
                {"..", 'I'}, {".---", 'J'}, {"-.-", 'K'}, {".-..", 'L'}, {"--", 'M'}, {"-.", 'N'}, {"---", 'O'}, {".--.", 'P'},
                {"--.-", 'Q'}, {".-.", 'R'}, {"...", 'S'}, {"-", 'T'}, {"..-", 'U'}, {"...-", 'V'}, {".--", 'W'}, {"-..-", 'X'},
                {"-.--", 'Y'}, {"--..", 'Z'}
            };

            string[] message = Console.ReadLine().Split();
            string decrypted = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == "|")
                {
                    decrypted += " ";
                }
                else if (morse.ContainsKey(message[i]))
                {
                    decrypted += morse[message[i]];
                }
            }

            Console.WriteLine(decrypted);
        }
    }
}
