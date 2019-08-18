namespace P08_LettersChangeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P08_LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<double> nums = new List<double>();

            foreach (string str in strings)
            {
                char frontLetter = str[0];
                char backLetter = str[str.Length - 1];
                double number = double.Parse(str.Substring(1, str.Length - 2));

                if (char.IsUpper(frontLetter))
                {
                    number /= (frontLetter - '@');
                }
                else
                {
                    number *= (frontLetter - '`');
                }

                if (char.IsUpper(backLetter))
                {
                    number -= (backLetter - '@');
                }
                else
                {
                    number += (backLetter - '`');
                }

                nums.Add(number);
            }

            Console.WriteLine($"{nums.Sum():F2}");
        }
    }
}