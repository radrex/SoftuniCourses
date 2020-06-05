namespace P06_ExtractEmails
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class P06_ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();       
            string pattern = @"(?<=\s)[A-Za-z0-9]+[_.-]*[A-Za-z0-9]+@[A-Za-z]+-*[A-Za-z]+(?:\.[A-Za-z]+-*[A-Za-z])+";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
