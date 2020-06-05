namespace P05_DigitsLettersAndOther
{
    using System;

    class P05_DigitsLettersAndOther
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string digits = string.Empty;
            string letters = string.Empty;
            string otherSymbols = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    digits += str[i];
                }
                else if (Char.IsLetter(str[i]))
                {
                    letters += str[i];
                }
                else
                {
                    otherSymbols += str[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherSymbols);
        }
    }
}